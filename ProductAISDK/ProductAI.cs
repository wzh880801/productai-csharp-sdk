using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

using ParaPair = System.Collections.Generic.Dictionary<string, string>;
namespace ProductAI.API {
    public class ProductAIService {
        public class ProductAIAsyncResult {
            public ProductAIService APIInstance;
            public HttpWebRequest RequestObject;
        };

        const string ssfClientUrl = "https://api.productai.cn";
        const string ssfClientVersion = "1";

        string mAccessKeyId = "";
        string mSecretKey = "";


        const string ffBoundaryString = "---------------------------";
        const string ffDataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
        const string ffHeaderTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";

        const string imageSetServiceType = "image_sets";
        const string imageSetServiceId = "_0000014";

        public ProductAIService(string accessKeyId, string secretKey) {
            if (string.IsNullOrEmpty(accessKeyId) || string.IsNullOrEmpty(secretKey)) {
                throw new Exception(" Parameter Error!check your accessKeyId，secretKey input!");
            }
            mAccessKeyId = accessKeyId;
            mSecretKey = secretKey;
        }

        /// <summary>
        /// request async,use image binarys to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="fileBytes"></param>
        /// <param name="options"></param>
        /// <param name="callBack"></param>
        /// <param name="request method"></param>
        /// <returns>async result use to end request and get result</returns>
        public IAsyncResult BeginSubmitFileToSearch(string serviceType, string serviceID, byte[] fileBytes,
            ParaPair options, AsyncCallback callBack, string method = "POST") {
            HttpWebRequest wr = submitFileToSearchInitClient(serviceType, serviceID, fileBytes, options, method);
            return requestAsync(wr, callBack);
        }

        /// <summary>
        /// request async,use local file to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="callBack"></param>
        /// <param name="request method"></param>
        /// <returns>async result use to end request and get result</returns>
        public IAsyncResult BeginSubmitFileToSearch(string serviceType, string serviceID, string filePath,
         ParaPair options, AsyncCallback callBack, string method = "POST") {
            byte[] bytes = getFileBytes(filePath);
            return BeginSubmitFileToSearch(serviceType, serviceID, bytes, options, callBack, method);
        }

        /// <summary>
        /// use image binarys to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <param name="method"></param>
        /// <returns>false request success,true request failed</returns>
        public bool SubmitFileToSearch(string serviceType, string serviceID, string filePath,
            ParaPair options, out string respContent, string method = "POST") {
            byte[] bytes = getFileBytes(filePath);
            return SubmitFileToSearch(serviceType, serviceID, bytes, options,out respContent, method);
        }


        /// <summary>
        /// use local file to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="fileBytes"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <param name="method"></param>
        /// <returns>false request success,true request failed</returns>
        public bool SubmitFileToSearch(string serviceType, string serviceID,
            byte[] fileBytes, ParaPair options, out string reponseRes ,string method = "POST") {
            HttpWebRequest wr = submitFileToSearchInitClient(serviceType, serviceID, fileBytes, options, method);
            return request(wr, out reponseRes);
            
        }

        /// <summary>
        /// request async , use image url to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="imageUrl"></param>
        /// <param name="options"></param>
        /// <param name="callBack"></param>
        /// <param name="method"></param>
        /// <returns>async result use to end request and get result</returns>
        public IAsyncResult BeginSubmitFormToSearch(string serviceType, string serviceID, string imageUrl,
            ParaPair options, AsyncCallback callBack, string method = "POST") {
            HttpWebRequest wr = submitFormToSearchInitClient(serviceType, serviceID, imageUrl, options, method);
            return requestAsync(wr, callBack);
        }

        /// <summary>
        /// use image url to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="url"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <param name="method"></param>
        /// <returns>false request success,true request failed</returns>
        public bool SubmitFormToSearch(string serviceType, string serviceID, string url,
            ParaPair options,out string respContent,string method = "POST") {
            HttpWebRequest wr = submitFormToSearchInitClient(serviceType, serviceID, url, options, method);
            return request(wr, out respContent);
        }

        /// <summary>
        /// request async,add a image to productAI imageset by image url
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="imageUrl"></param>
        /// <param name="options"></param>
        /// <param name="callBack"></param>
        /// <param name="method"></param>
        /// <returns>async result use to end request and get result</returns>
        public IAsyncResult BeginAddImageToImageSet(string imageSetId, string imageUrl, ParaPair options,
           AsyncCallback callBack, string method = "POST") {
            HttpWebRequest wr = addImageToImageSetInitClient(imageSetId, imageUrl, options, method);
            return requestAsync(wr, callBack);
        }

        /// <summary>
        /// add a image to productAI imageset by image url
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="imageUrl"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <param name="method"></param>
        /// <returns>false request success,true request failed</returns>
        public bool AddImageToImageSet(string imageSetId, string imageUrl, ParaPair options,out string respContent, string method = "POST") {
            HttpWebRequest wr = addImageToImageSetInitClient(imageSetId, imageUrl, options, method);
            return request(wr, out respContent);
        }


        /// <summary>
        /// request async batch add images to productAI imageset by CSV file 
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="callBack"></param>
        /// <param name="method"></param>
        /// <returns>async result use to end request and get result</returns>
        public IAsyncResult BeginAddImageByFile(string imageSetId, string filePath, ParaPair options,
          AsyncCallback callBack, string method = "POST") {
            HttpWebRequest wr = imageSetControlByFileInitLocal(imageSetId, filePath, options, "urls_to_add", method);
            return requestAsync(wr, callBack);
        }

        /// <summary>
        /// batch add images to productAI imageset by CSV file
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <param name="method"></param>
        /// <returns>false request success,true request failed</returns>
        public bool AddImageByFile(string imageSetId, string filePath, ParaPair options,
            out string respContent, string method = "POST") {
            HttpWebRequest wr = imageSetControlByFileInitLocal(imageSetId, filePath, options, "urls_to_add", method);
            return request(wr, out respContent);
        }
        /// <summary>
        /// request  async ,batch delete images from productAI imageset by CSV file
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="callBack"></param>
        /// <param name="method"></param>
        /// <returns>async result use to end request and get result</returns>
        public IAsyncResult BeginDeleteImageByFile(string imageSetId, string filePath, ParaPair options,
            AsyncCallback callBack, string method = "POST") {
            HttpWebRequest wr = imageSetControlByFileInitLocal(imageSetId, filePath, options, "urls_to_delete", method);
            return requestAsync(wr, callBack);
        }

        /// <summary>
        /// batch delete images from imageset by CSV file
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <param name="request method"></param>
        /// <returns>false request success,true request failed</returns>
        public bool DeleteImageByFile(string imageSetId, string filePath, ParaPair options,
            out string respContent, string method = "POST") {
            HttpWebRequest wr = imageSetControlByFileInitLocal(imageSetId, filePath, options, "urls_to_delete", method);
            return request(wr, out respContent);
        }

        /// <summary>
        /// end request and get request result
        /// </summary>
        /// <param name="res"></param>
        /// <param name="RespContent"></param>
        /// <returns>false request success,true request failed</returns>
        public bool EndRequest(ProductAIAsyncResult res, out string RespContent) {
            return GetRespRes(res.RequestObject, out RespContent);
        }
        protected static string shortUuid() {
            return Guid.NewGuid().ToString("N");
        }
        protected string getTimeStamp() {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        protected ParaPair clientHeaders(string accessKeyId, string method = "POST") {
            string timeStamp = getTimeStamp();
            ParaPair header = new ParaPair();
            header.Add("x-ca-accesskeyid", accessKeyId);
            header.Add("x-ca-version", ssfClientVersion);
            header.Add("x-ca-timestamp", timeStamp);
            header.Add("x-ca-signaturenonce", shortUuid());
            header.Add("requestmethod", method);
            header.Add("x-ca-signature", "");
            return header;
        }
        protected string getFileMd5(byte[] file) {
            byte[] md5Bytes;
            using (MemoryStream stream = new MemoryStream(file)) {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5Bytes = md5.ComputeHash(stream);
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Bytes.Length; i++) {
                sb.Append(md5Bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
        protected ParaPair checkNotExcluded(ParaPair source) {
            ParaPair res = new ParaPair();
            string[] excludeKeys = { "x-ca-signature", "x-ca-file-md5" };

            foreach (var item in source) {
                bool isExclude = false;
                for (int i = 0; i < excludeKeys.Length; i++) {
                    if (item.Key.Equals(excludeKeys[i])) {
                        isExclude = true;
                        break;
                    }
                }
                if (!isExclude) {
                    res.Add(item.Key, item.Value);
                }
            }
            return res;
        }
        protected string joinParam(List<string> sortValue) {
            StringBuilder result = new StringBuilder();
            result.Append(sortValue[0]);
            for (int i = 1; i < sortValue.Count; i++) {
                result.Append("&" + sortValue[i]);
            }
            return result.ToString();
        }
        protected ParaPair mergePairAndSort(ParaPair source, ParaPair dest) {
            if (null == source) {
                throw new Exception("Parameter Error!,check your header and forms input");
            }
            ParaPair res = new ParaPair(source);
            if (null != dest) {
                foreach (var form in dest) {
                    res[form.Key] = form.Value;
                }
            }
            res = res.OrderBy(x => x.Key).ToDictionary(item => item.Key, item => item.Value);
            return res;
        }
        protected string paramWebString(ParaPair param, bool escStr = false) {
            string rs = "";
            List<string> sortValue = new List<string>();
            foreach (var item in param) {
                string key = item.Key;
                string value = item.Value;
                if (escStr) {
                    key = Uri.EscapeDataString(key);
                    value = Uri.EscapeDataString(value);
                }
                sortValue.Add(key + "=" + value);
            }
            rs = joinParam(sortValue);
            return rs;
        }
        protected string clientSignature(ParaPair headers,
            ParaPair form, string secretKey) {
            ParaPair calcParams = checkNotExcluded(headers);
            calcParams = mergePairAndSort(calcParams, form);
            string stringToSignature = paramWebString(calcParams);
            if (string.IsNullOrEmpty(stringToSignature)) {
                throw new Exception("Signature String Null!check your headers and forms input");
            }
            HMACSHA1 mac = new HMACSHA1();
            mac.Key = Encoding.UTF8.GetBytes(secretKey);
            byte[] textBytes = Encoding.UTF8.GetBytes(stringToSignature);
            byte[] hashBytes = mac.ComputeHash(textBytes);
            return Convert.ToBase64String(hashBytes);
        }
        protected HttpWebRequest configureWebClient(string url, ParaPair postForms, string method) {
            ParaPair headers =
                clientHeaders(mAccessKeyId, method);

            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Credentials = CredentialCache.DefaultCredentials;
            wr.Timeout = 20 * 1000;

            string signature = clientSignature(headers, postForms, mSecretKey);
            headers["x-ca-signature"] = signature;
            foreach (var header in headers) {
                wr.Headers.Add(header.Key, header.Value);
            }
            return wr;
        }
        protected byte[] getFileBytes(string filePath) {
            byte[] bytes = null;
            if (!File.Exists(filePath)) {
                throw new Exception("文件：" + filePath + "不存在");
            }
            using (FileStream fsSource = new FileStream(filePath,
            FileMode.Open, FileAccess.Read)) {
                bytes = new byte[fsSource.Length];
                int bytesToRead = (int)fsSource.Length;
                int bytesReaded = 0;
                while (bytesToRead > 0) {
                    int n = fsSource.Read(bytes, bytesReaded, bytesToRead);
                    if (0 == n)
                        break;
                    bytesReaded += n;
                    bytesToRead -= n;
                }
            }
            return bytes;
        }
        protected void Post(HttpWebRequest wr, byte[] file,
            ParaPair forms, string fileFormDataName, string fileContentType) {
            string boundary = ffBoundaryString + DateTime.Now.Ticks.ToString("x");
            byte[] boundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            string fileHeader = string.Format(ffHeaderTemplate, fileFormDataName, "malongtest.jpg", fileContentType);
            byte[] headerBytes = Encoding.UTF8.GetBytes(fileHeader);
            
            using (Stream stream = wr.GetRequestStream()) {
                foreach (string key in forms.Keys) {
                    stream.Write(boundaryBytes, 0, boundaryBytes.Length);
                    string formItem = string.Format(ffDataTemplate, key, forms[key]);
                    byte[] formItemBytes = Encoding.UTF8.GetBytes(formItem);
                    stream.Write(formItemBytes, 0, formItemBytes.Length);
                }
                stream.Write(boundaryBytes, 0, boundaryBytes.Length);
                stream.Write(headerBytes, 0, headerBytes.Length);
                stream.Write(file, 0, file.Length);
                byte[] trailer = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
                stream.Write(trailer, 0, trailer.Length);
            }
            
        }
        protected void Post(HttpWebRequest wr, ParaPair forms) {
            wr.ContentType = "application/x-www-form-urlencoded";
            //try {
            using (Stream stream = wr.GetRequestStream()) {
                string formContent = paramWebString(forms, true);
                byte[] byteContent = Encoding.UTF8.GetBytes(formContent);
                stream.Write(byteContent, 0, byteContent.Length);
            }
            //} catch (Exception ex) {
            //    throw new Exception("Request failed!please chek your network");
            //}
        }
        protected IAsyncResult requestAsync(HttpWebRequest wr, AsyncCallback RequestCallback) {
            ProductAIAsyncResult productRes = new ProductAIAsyncResult();
            productRes.APIInstance = this;
            productRes.RequestObject = wr;
            IAsyncResult res = wr.BeginGetRequestStream(new AsyncCallback(RequestCallback), productRes);
            return res;
        }
        protected bool request(HttpWebRequest wr, out string respContent) {
            return GetRespRes(wr, out respContent);
        }

        protected bool GetRespRes(HttpWebRequest wr, out string respContent) {
            bool isErro = false;
            WebResponse wresp = null;
            try {
                wresp = wr.GetResponse();
                using (Stream stream = wresp.GetResponseStream()) {
                    StreamReader reader = new StreamReader(stream);
                    respContent = reader.ReadToEnd();
                }
            } catch (WebException ex) {
                System.Console.WriteLine(ex.Message);
                WebResponse resErro = ex.Response;
                using (Stream stream = resErro.GetResponseStream()) {
                    StreamReader reader = new StreamReader(stream);
                    respContent = reader.ReadToEnd();
                }
                isErro = true;
            }
            return isErro;
        }
        protected string urlSearch(string serviceType, string serviceId) {
            string url = ssfClientUrl + "/" + serviceType + "/" + serviceId + "/";
            return url;
        }

        protected string urlImage(string ImageSetId) {
            string url = urlSearch(imageSetServiceType, imageSetServiceId);
            url += ImageSetId;
            return url;
        }

        protected HttpWebRequest submitFileToSearchInitClient(string serviceType, string serviceID, byte[] file,
            ParaPair options, string method = "POST") {
            if (string.IsNullOrEmpty(serviceType) || string.IsNullOrEmpty(serviceID)) {
                throw new Exception("Parameter Error!check your  serviceType and serviceID input");
            }
            string postUrl = urlSearch(serviceType, serviceID);
            ParaPair postForm = new ParaPair();
            string loc = options["loc"];
            if (null != loc) {
                postForm["loc"] = loc;
            }
            string count = options["count"];
            if (null != count) {
                postForm["count"] = count;
            }
            ParaPair headers =
                clientHeaders(mAccessKeyId, method);

            string fileMD5 = getFileMd5(file);
            headers["x-ca-file-md5"] = fileMD5;
            HttpWebRequest wr = configureWebClient(postUrl, postForm, method);
            Post(wr, file, postForm, "search", "image/jpegcv");
            return wr;

        }
        protected HttpWebRequest submitFormToSearchInitClient(string serviceType, string serviceID, string imageUrl,
            ParaPair options, string method = "POST") {
            string postUrl = urlSearch(serviceType, serviceID);
            ParaPair postForm = new ParaPair();
            string loc = options["loc"];
            if (null != loc) {
                postForm["loc"] = loc;
            }
            string url = imageUrl;
            if (null != url) {
                postForm["url"] = url;
            }
            HttpWebRequest wr = configureWebClient(postUrl, postForm, method);
            Post(wr, postForm);
            return wr;
        }
        protected HttpWebRequest addImageToImageSetInitClient(string imageSetId, string imageUrl,
            ParaPair options, string method = "POST") {
            string meta = "";
            if (null != options["meta"]) {
                meta = options["meta"];
            }
            string postUrl = urlImage(imageSetId);
            ParaPair postForms = new ParaPair();
            postForms["image_url"] = imageUrl;
            postForms["meta"] = meta;

            HttpWebRequest wr = configureWebClient(postUrl, postForms, method);
            Post(wr, postForms);
            return wr;
        }



        protected HttpWebRequest imageSetControlByFileInitLocal(string imageSetId, string filePath,
            ParaPair options, string controlStr, string method = "POST") {
            string postUrl = urlImage(imageSetId);
            HttpWebRequest wr = configureWebClient(postUrl, null, method);
            byte[] bytes = getFileBytes(filePath);
            Post(wr, bytes, new ParaPair(), controlStr, "");
            return wr;
        }



    }
}
