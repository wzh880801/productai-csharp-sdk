using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ProductAI.API {
    class ProductAIServiceAPI {
        protected const string pAIUrl = "https://api.productai.cn";
        //protected const string pAIUrl = "http://api-test.productai.cn";
        protected const string pAIVersion="1";

        protected string mAccessKeyId = "";
        protected string mSecretKey = "";

        const string imageSetServiceType = "image_sets";
        const string imageSetServiceId = "_0000014";

        public ProductAIServiceAPI(string accessKeyId, string secretKey) {
            mAccessKeyId = accessKeyId;
            mSecretKey = secretKey;
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
            byte[] fileBytes, Dictionary<string,string> options,
            out string respContent) {
            string url = urlSearch(serviceType, serviceID);
            Dictionary<string,string> headers = getCommonHeader(options);

            HttpForm form = new HttpForm();
            foreach (var param in options) {
                form.AddField(param.Key,param.Value);
            }
            form.AddBinary("search", fileBytes, "malongtest.jpg", "image/jpegcv");
            HttpPost hp = new HttpPost(url,headers,form);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }
        public bool SubmitFormToSearch(string serviceType, string serviceID,
            string PictureUrl,Dictionary<string,string> options,
            out string respContent) {
            string searchUrl = urlSearch(serviceType,serviceID);
            Dictionary<string, string> parameters = new Dictionary<string, string>(options);
            parameters.Add("url", PictureUrl);
            Dictionary<string,string> headers = getCommonHeader(parameters);
            UrlEncodeForm form =new UrlEncodeForm();
            foreach (var param in parameters) {
                form.AddField(param.Key,param.Value);
            }
            HttpPost hp = new HttpPost(searchUrl,headers,form);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }

        public bool AddImageToImageSet(string imageSetId, string imageUrl,
            Dictionary<string,string> options,
            out string respContent) {
            string postUrl = urlImageSet(imageSetId);
            Dictionary<string, string> parameters =
                new Dictionary<string, string>(options);
            parameters.Add("image_url",imageUrl);
            Dictionary<string,string> headers = getCommonHeader(parameters);
            UrlEncodeForm form = new UrlEncodeForm();
            foreach (var param in parameters) {
                form.AddField(param.Key,param.Value);
            }
            HttpPost hp = new HttpPost(postUrl, headers,form);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }

        public bool AddImageByFile(string imageSetId, string filePath,
            Dictionary<string,string> options,
            out string respContent) {
            return ImageSetFileControl(imageSetId, filePath, "urls_to_add", options,out respContent);
        }
        public bool DeleteImageByFile(string imageSetId, string filePath,
            Dictionary<string, string> options,
            out string respContent) {
            return ImageSetFileControl(imageSetId, filePath, "urls_to_delete", options, out respContent);
        }
        public bool ImageSetFileControl(
            string imageSetId, string filePath,string ControlStr,
            Dictionary<string, string> options,
            out string respContent) {
            string postUrl = urlImageSet(imageSetId);
            Dictionary<string,string> headers = getCommonHeader( null);
            HttpForm form = new HttpForm();
            byte[] bytes = getFileBytes(filePath);
            form.AddBinary(ControlStr,bytes,"Imageset.csv");
            HttpPost hp = new HttpPost(postUrl,headers,form);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }

        protected string urlSearch(string serviceType, string serviceId) {
            string url = pAIUrl + "/" + serviceType + "/" + serviceId + "/";
            return url;
        }
        protected string urlImageSet(string ImageSetId) {
            string url = urlSearch(imageSetServiceType, imageSetServiceId);
            url += ImageSetId;
            return url;
        }

        protected static string shortUuid() {
            return Guid.NewGuid().ToString("N");
        }
        protected string getTimeStamp() {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        protected Dictionary<string, string> serviceHeaders(string accessKeyId, string method = "POST") {
            string timeStamp = getTimeStamp();
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("x-ca-accesskeyid", accessKeyId);
            header.Add("x-ca-version", pAIVersion);
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
        protected Dictionary<string, string> checkNotExcluded(Dictionary<string, string> source) {
            Dictionary<string, string> res = new Dictionary<string, string>();
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
        protected string serviceSignature(Dictionary<string, string> headers,
            Dictionary<string, string> parameters, string secretKey) {
            Dictionary<string, string> calcParams = checkNotExcluded(headers);
            if (null != parameters) {
                foreach (var param in parameters) {
                    calcParams.Add(param.Key, param.Value);
                }
            }
            SignatureBytes sb = new SignatureBytes();
            foreach (var param in calcParams) {
                sb.AddField(param.Key, param.Value);
            }   
            HMACSHA1 mac = new HMACSHA1();
            mac.Key = Encoding.UTF8.GetBytes(secretKey);
            byte[] hashBytes = mac.ComputeHash(sb.GetData());
            return Convert.ToBase64String(hashBytes);
        }
        protected bool GetRespResult(HttpWebRequest wr,out string respContent) {
            bool isErr = false;
            try {
                WebResponse resp = wr.GetResponse();
                using (Stream stream = resp.GetResponseStream()) {
                    StreamReader reader = new StreamReader(stream);
                    respContent = reader.ReadToEnd();
                }
            } catch(WebException ex) {
                isErr = true;
                respContent = ex.Message;
                if (null != ex.Response) {
                    Stream steam = ex.Response.GetResponseStream();
                    StreamReader reader = new StreamReader(steam);
                    string errResp = reader.ReadToEnd();
                    respContent += "\r\n" + errResp;
                }
            }
            return isErr;
        }
        protected bool writeForm(HttpWebRequest wr, IForms form, out string respContent) {
            bool isErr = false;
            wr.ContentType = form.ContentType;
            try {
                using (Stream stream = wr.GetRequestStream()) {
                    byte[] formData = form.GetData();
                    stream.Write(formData, 0, formData.Length);
                }
            }catch (WebException ex) {
                isErr = true;
                respContent = ex.Message;
                return isErr;
            }
            respContent = "";
            return isErr;
        }
        protected bool post(HttpWebRequest wr,IForms form,out string respContent) {
            if (writeForm(wr, form, out respContent)) {
                return true;
            } else {
                return GetRespResult(wr, out respContent);
            }     
        }
        protected Dictionary<string,string> getCommonHeader(Dictionary<string,string> parameters) {
            Dictionary<string, string> headers = serviceHeaders(mAccessKeyId);
            string signature = serviceSignature(checkNotExcluded( headers),parameters,mSecretKey);
            headers["x-ca-signature"] = signature;
            return headers;
        }
        protected byte[] getFileBytes(string filePath) {
            byte[] bytes = null;
            if (!File.Exists(filePath)) {
                throw new Exception("File：" + filePath + "Not Exist!");
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
    }
}
