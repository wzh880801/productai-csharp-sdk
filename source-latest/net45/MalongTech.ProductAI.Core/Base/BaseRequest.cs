using System;
using System.Collections.Generic;

namespace MalongTech.ProductAI.Core
{
    public abstract class BaseRequest<T>
        where T : BaseResponse
    {
        private static Dictionary<int, string> _contentTypeDicts = EnumHelper.ToDictionary(typeof(ContentType));
        private static Dictionary<int, string> _languageDicts = typeof(LanguageType).ToDictionary();
        private Dictionary<string, string> _headers = new Dictionary<string, string>();

        /// <summary>
        /// domain
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// User Agent. You can override this property to use your own UA
        /// </summary>
        public virtual string UserAgent { get; } = "Product AI C# SDK 1.0";

        public HttpMethod RequestMethod { get; set; } = HttpMethod.POST;

        /// <summary>
        /// api url address
        /// </summary>
        public abstract string ApiUrl { get; }

        public ContentType ContentType { get; set; } = ContentType.Default;

        public virtual string ContentTypeHeader
        {
            get
            {
                return _contentTypeDicts[(int)this.ContentType];
            }
        }

        public abstract string QueryString { get; }

        /// <summary>
        /// When you are using POST, this is the request body you want to parse.
        /// </summary>
        public virtual byte[] QueryBytes { get; }

        private LanguageType _language = LanguageType.English;
        /// <summary>
        /// Get or Set the language of the api results.
        /// The default is English.
        /// <para>This value will be override if IProfile.GlobalLanguage != null</para>
        /// </summary>
        public virtual LanguageType Language
        {
            get
            {
                return this._language;
            }
            set
            {
                this.SetHeader("Accept-Language", _languageDicts[(int)value]);
                this._language = value;
            }
        }

        /// <summary>
        /// Custom headers
        /// </summary>
        public virtual Dictionary<string, string> Headers
        {
            get
            {
                return _headers;
            }
        }

        /// <summary>
        /// Set the custom header
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetHeader(string key, string value)
        {
            if (!_headers.ContainsKey(key))
                _headers.Add(key, value);
            else
                _headers[key] = value;
        }

        /// <summary>
        /// Remove the custom header
        /// </summary>
        /// <param name="key"></param>
        public void RemoveHeader(string key)
        {
            if (_headers.ContainsKey(key))
                _headers.Remove(key);
        }

        public BaseRequest()
        {
            this.SetHeader("Accept-Encoding", "gzip, deflate");
            this.Language = LanguageType.English;
        }
    }
}