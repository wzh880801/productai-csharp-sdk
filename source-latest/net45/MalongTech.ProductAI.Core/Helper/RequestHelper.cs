using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace MalongTech.ProductAI.Core
{
    internal class RequestHelper
    {
        private static Dictionary<int, string> _httpMethodDics = EnumHelper.ToDictionary(typeof(HttpMethod));

        #region private methods    

        private static HttpWebRequest CreateRequest<T>(BaseRequest<T> _request)
            where T : BaseResponse
        {
            var api = _request.ApiUrl;
            if (_request.RequestMethod == HttpMethod.GET && !string.IsNullOrWhiteSpace(_request.QueryString))
            {
                var uri = new Uri(api);
                if (!string.IsNullOrWhiteSpace(uri.Query))
                    api = api + ("&" + _request.QueryString);
                else
                    api = api + "?" + _request.QueryString;
            }

            var request = WebRequest.Create(api) as HttpWebRequest;

            if (!string.IsNullOrWhiteSpace(_request.UserAgent))
                request.UserAgent = _request.UserAgent;

            request.Method = _httpMethodDics[(int)_request.RequestMethod];

            if (!string.IsNullOrWhiteSpace(_request.ContentTypeHeader))
                request.ContentType = _request.ContentTypeHeader;

            if (_request.Headers != null)
            {
                foreach (var k in _request.Headers)
                    request.Headers.Add(k.Key, k.Value);
            }

            return request;
        }

        private static void WriteRequestParas(HttpWebRequest request, string query)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(query);
            request.ContentLength = buffer.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(buffer, 0, buffer.Length);
            }
        }

        private static void WriteRequestParas(HttpWebRequest request, byte[] query)
        {
            request.ContentLength = query.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(query, 0, query.Length);
            }
        }

        private static byte[] ReadStreamBytes(Stream sourceStream)
        {
            var bytes = new List<byte>();
            int bufferSize = 1024;
            using (BinaryReader br = new BinaryReader(sourceStream, Encoding.UTF8))
            {
                while (true)
                {
                    byte[] buffer = br.ReadBytes(bufferSize);
                    bytes.AddRange(buffer);
                    if (buffer.Length != bufferSize)
                        break;
                }
            }
            return bytes.ToArray();
        }

        #endregion

        #region sync

        internal static HttpResponse GetResponse<T>(BaseRequest<T> _request)
            where T : BaseResponse
        {
            HttpResponse httpResponse = null;
            HttpWebResponse response = null;

            var request = CreateRequest(_request);
            try
            {
                if (_request.RequestMethod != HttpMethod.GET)
                {
                    if (_request.QueryBytes == null || _request.QueryBytes.Length == 0)
                    {
                        if (!string.IsNullOrWhiteSpace(_request.QueryString))
                            WriteRequestParas(request, _request.QueryString);
                        else
                            request.ContentLength = 0;
                    }
                    else
                    {
                        WriteRequestParas(request, _request.QueryBytes);
                    }
                }

                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            httpResponse = new HttpResponse(response);
            var encoding = response.Headers["Content-Encoding"];
            using (Stream s = response.GetResponseStream())
            {
                if (!string.IsNullOrEmpty(encoding))
                {
                    if (encoding.ToLower().Contains("gzip"))
                    {
                        GZipStream st = new GZipStream(s, CompressionMode.Decompress);
                        httpResponse.ResponseBytes = ReadStreamBytes(st);
                    }
                    else if (encoding.ToLower().Contains("deflate"))
                    {
                        DeflateStream st = new DeflateStream(s, CompressionMode.Decompress);
                        httpResponse.ResponseBytes = ReadStreamBytes(st);
                    }
                    else
                    {
                        httpResponse.ResponseBytes = ReadStreamBytes(s);
                    }
                }
                else
                {
                    httpResponse.ResponseBytes = ReadStreamBytes(s);
                }
            }

            response.Dispose();

            return httpResponse;
        }

        #endregion

        #region async

        internal static async Task<HttpResponse> GetResponseAsync<T>(BaseRequest<T> _request)
            where T : BaseResponse
        {
            HttpResponse httpResponse = null;
            HttpWebResponse response = null;

            var request = CreateRequest(_request);
            try
            {
                if (_request.RequestMethod != HttpMethod.GET)
                {
                    if (_request.QueryBytes == null || _request.QueryBytes.Length == 0)
                    {
                        if (!string.IsNullOrWhiteSpace(_request.QueryString))
                            WriteRequestParas(request, _request.QueryString);
                        else
                            request.ContentLength = 0;
                    }
                    else
                    {
                        WriteRequestParas(request, _request.QueryBytes);
                    }
                }

                response = await request.GetResponseAsync() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    if (e is WebException)
                    {
                        response = ((WebException)e).Response as HttpWebResponse;
                        break;
                    }
                }
            }

            httpResponse = new HttpResponse(response);
            var encoding = response.Headers["Content-Encoding"];
            using (Stream s = response.GetResponseStream())
            {
                if (!string.IsNullOrEmpty(encoding))
                {
                    if (encoding.ToLower().Contains("gzip"))
                    {
                        GZipStream st = new GZipStream(s, CompressionMode.Decompress);
                        httpResponse.ResponseBytes = ReadStreamBytes(st);
                    }
                    else if (encoding.ToLower().Contains("deflate"))
                    {
                        DeflateStream st = new DeflateStream(s, CompressionMode.Decompress);
                        httpResponse.ResponseBytes = ReadStreamBytes(st);
                    }
                }
                else
                {
                    httpResponse.ResponseBytes = ReadStreamBytes(s);
                }
            }

            response.Dispose();

            return httpResponse;
        }

        #endregion
    }
}