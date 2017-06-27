using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace MalongTech.ProductAI.Core
{
    /// <summary>
    /// This provide the basic implementation of IWebClient. 
    /// It could automatically handle the url signature and parse the response.
    /// </summary>
    public class DefaultProductAIClient : IWebClient
    {
        private string _host = "api.productai.cn";
        private IProfile _profile = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile">Your account profile</param>
        public DefaultProductAIClient(IProfile profile)
        {
            this._profile = profile;
        }

        public DefaultProductAIClient()
        {

        }

        /// <summary>
        /// Api Host.
        /// Default is api.productai.cn. For testing purpose, you could change it to the one you need.
        /// </summary>
        public string Host
        {
            get
            {
                return this._host;
            }
            set
            {
                this._host = value;
            }
        }

        /// <summary>
        /// Get or Set your profile
        /// </summary>
        public IProfile Profile
        {
            get
            {
                return this._profile;
            }
            set
            {
                this._profile = value;
            }
        }

        /// <summary>
        /// The Encoding used to parse the response content.
        /// Default is UTF8
        /// </summary>
        public Encoding ParseEncoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// Set the api Host & signature
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        protected virtual void SetHostAndSignature<T>(BaseRequest<T> request)
            where T : BaseResponse
        {
            if (request == null)
                throw new ClientException("SDK.Request", "Request can not be null!");
            if (_profile == null)
                throw new ClientException("SDK.Profile", "Profile can not be null!");

            if (string.IsNullOrWhiteSpace(_profile.AccessKeyId) || string.IsNullOrWhiteSpace(_profile.SecretKey))
                throw new ClientException("SDK.Profile", "Invalid accessKeyId/accessKey");

            if (request != null)
            {
                var dics = new Dictionary<string, string>();

                dics.Add("x-ca-accesskeyid", _profile.AccessKeyId);
                dics.Add("x-ca-version", _profile.Version);
                dics.Add("x-ca-timestamp", string.Format("{0}", (long)(DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds)));
                dics.Add("x-ca-signaturenonce", Guid.NewGuid().ToString("N"));
                dics.Add("requestmethod", "POST");

                foreach (var dic in dics)
                    request.SetHeader(dic.Key, dic.Value);

                var properties = request.GetType().GetProperties();
                foreach (var p in properties)
                {
                    var ca = p.GetCustomAttribute(typeof(ParaSignAttribute));
                    if (ca != null)
                    {
                        var _ca = ca as ParaSignAttribute;
                        var value = p.GetValue(request);
                        if (p.PropertyType == typeof(System.String))
                        {
                            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                                dics.Add(_ca.Name, string.Format("{0}", value));
                        }
                        else if (p.PropertyType == typeof(int?))
                        {
                            var v = value as int?;
                            if (v != null)
                                dics.Add(_ca.Name, string.Format("{0}", value));
                        }
                        else if (p.PropertyType == typeof(double?))
                        {
                            var v = value as double?;
                            if (v != null)
                                dics.Add(_ca.Name, string.Format("{0}", value));
                        }
                    }
                }

                request.SetHeader("x-ca-signature", SignnatureHelper.Signnature(_profile.SecretKey, dics));

                foreach (var p in properties)
                {
                    if (p.Name == "Host" && p.CanWrite && p.PropertyType == typeof(System.String))
                    {
                        p.SetValue(request, _host);
                        break;
                    }
                }

                if (this._profile.GlobalLanguage != null)
                    request.Language = this._profile.GlobalLanguage.Value;
            }
        }

        /// <summary>
        /// Parse the response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="httpResponse"></param>
        /// <returns></returns>
        private T Parse<T>(BaseRequest<T> request, HttpResponse httpResponse)
            where T : BaseResponse
        {
            var responseString = ParseEncoding.GetString(httpResponse.ResponseBytes);

            if (string.IsNullOrWhiteSpace(responseString))
            {
                var obj = System.Activator.CreateInstance<T>();
                obj.Headers = httpResponse.Headers;
                obj.StatusCode = httpResponse.StatusCode;
                return obj;
            }

            var t = System.Activator.CreateInstance<T>();
            t.ResponseBase64String = Convert.ToBase64String(httpResponse.ResponseBytes);
            t.Headers = httpResponse.Headers;
            t.StatusCode = httpResponse.StatusCode;

            if (t.ResponseType == ResponseType.Json)
            {
                var _t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                _t.ResponseBase64String = t.ResponseBase64String;
                _t.Headers = httpResponse.Headers;
                _t.StatusCode = httpResponse.StatusCode;

                if ((int)_t.StatusCode >= 500)
                    throw new ServerException(string.Format("{0}", _t.ErrorCode), string.Format("{0}-{1}", _t.ErrorMsg, _t.Message));
                else if ((int)_t.StatusCode >= 400)
                    throw new ClientException(string.Format("{0}", _t.ErrorCode), string.Format("{0}-{1}", _t.ErrorMsg, _t.Message), _t.RequestId);

                return _t;
            }

            return t;
        }

        /// <summary>
        /// Get the response synchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual T GetResponse<T>(BaseRequest<T> request)
            where T : BaseResponse
        {
            SetHostAndSignature(request);

            var response = RequestHelper.GetResponse(request);
            return this.Parse(request, response);
        }

        /// <summary>
        /// Get the response asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual async Task<T> GetResponseAsync<T>(BaseRequest<T> request)
            where T : BaseResponse
        {
            SetHostAndSignature(request);

            var response = await RequestHelper.GetResponseAsync(request);
            return this.Parse(request, response);
        }
    }
}