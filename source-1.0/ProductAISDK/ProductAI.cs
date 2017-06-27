using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ProductAI.API {
    public class ProductAIServiceAPI {
        protected const string pAIUrl = "https://api.productai.cn";
        //protected const string pAIUrl = "http://api-test.productai.cn";
        protected const string pAIVersion="1";

        protected string mAccessKeyId = "";
        protected string mSecretKey = "";

        const string imageSetServiceType = "image_sets";
        const string imageSetServiceId = "_0000014";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessKeyId"></param>
        /// <param name="secretKey"></param>
        public ProductAIServiceAPI(string accessKeyId, string secretKey) {
            mAccessKeyId = accessKeyId;
            mSecretKey = secretKey;
        }

        /// <summary>
        /// use image binarys to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <returns>false request success,true request failed</returns>
        public bool SubmitFileToSearch(string serviceType, string serviceID,
            byte[] fileBytes, Dictionary<string, string> options,
            out string respContent) {
            HttpPost hp = SubmitFileToSearchP(serviceType, serviceID, fileBytes, options);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }

        /// <summary>
        /// request async,use local file to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <returns>async result use to end request and get result</returns>
        public bool SubmitFileToSearch(string serviceType, string serviceID,
            string filePath, Dictionary<string, string> options,
            out string respContent) {
            byte[] fileBytes = Functions.getFileBytes(filePath);
            return SubmitFileToSearch(serviceType, serviceID, fileBytes, options, out respContent);
        }

        /// <summary>
        /// request async,use image binarys to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns>async result use to end request and get result</returns>
        public void SubmitFileToSearchAsync(string serviceType, string serviceID,
           string filePath, Dictionary<string, string> options,
           Action<bool, string> callback) {
            byte[] fileBytes = Functions.getFileBytes(filePath);
            SubmitFileToSearchAsync(serviceType, serviceID, fileBytes, options, callback);
        }

        /// <summary>
        /// request async,use image binarys to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="fileBytes"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns>async result use to end request and get result</returns>
        public void SubmitFileToSearchAsync(string serviceType, string serviceID,
           byte[] fileBytes, Dictionary<string, string> options,
            Action<bool, string> callback) {
            HttpPost hp = SubmitFileToSearchP(serviceType, serviceID, fileBytes, options);
            hp.PostAsync(callback);
        }

        /// <summary>
        /// use image url to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="PictureUrl"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <returns>false request success,true request failed</returns>
        public bool SubmitFormToSearch(string serviceType, string serviceID,
            string PictureUrl, Dictionary<string, string> options,
            out string respContent) {
            HttpPost hp = SubmitFormToSearchP(serviceType, serviceID, PictureUrl, options);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }

        /// <summary>
        /// request async , use image url to experience productAI search service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <param name="serviceID"></param>
        /// <param name="PictureUrl"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns>async result use to end request and get result</returns>
        public void SubmitFormToSearchAsync(string serviceType, string serviceID,
            string PictureUrl, Dictionary<string, string> options,
            Action<bool, string> callback) {
            HttpPost hp = SubmitFormToSearchP(serviceType, serviceID, PictureUrl, options);
            hp.PostAsync(callback);
        }

        /// <summary>
        /// add a image to productAI imageset by image url
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="imageUrl"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <returns>false request success,true request failed</returns>
        public bool AddImageToImageSet(string imageSetId, string imageUrl,
            Dictionary<string, string> options,
            out string respContent) {
            HttpPost hp = AddImageToImageSetP(imageSetId, imageUrl, options);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }

        /// <summary>
        /// request async,add a image to productAI imageset by image url
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="imageUrl"></param>
        /// <param name="options"></param>
        /// <param name="callback"></param>
        /// <returns>async result use to end request and get result</returns>
        public void AddImageToImageSetAsync(string imageSetId, string imageUrl,
           Dictionary<string, string> options,
           Action<bool, string> callback) {
            HttpPost hp = AddImageToImageSetP(imageSetId, imageUrl, options);
            hp.PostAsync(callback);
        }

        /// <summary>
        /// batch add images to productAI imageset by CSV file
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <returns>false request success,true request failed</returns>
        public bool AddImageByFile(string imageSetId, string filePath,
            Dictionary<string, string> options,
            out string respContent) {
            HttpPost hp =
                ImageSetFileControlP(imageSetId, filePath, "urls_to_add", options);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }

        /// <summary>
        /// request async batch add images to productAI imageset by CSV file 
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="callBack"></param>
        /// <returns>async result use to end request and get result</returns>
        public void AddImageByFileAsync(string imageSetId, string filePath,
            Dictionary<string, string> options,
            Action<bool, string> callback) {
            HttpPost hp =
                ImageSetFileControlP(imageSetId, filePath, "urls_to_add", options);
            hp.PostAsync(callback);

        }

        /// <summary>
        /// batch delete images from imageset by CSV file
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="respContent"></param>
        /// <returns>false request success,true request failed</returns>
        public bool DeleteImageByFile(string imageSetId, string filePath,
            Dictionary<string, string> options,
            out string respContent) {
            HttpPost hp = ImageSetFileControlP(imageSetId, filePath, "urls_to_delete", options);
            hp.Post();
            respContent = hp.ResultText;
            return hp.IsError;
        }

        /// <summary>
        /// request  async ,batch delete images from productAI imageset by CSV file
        /// </summary>
        /// <param name="imageSetId"></param>
        /// <param name="filePath"></param>
        /// <param name="options"></param>
        /// <param name="callBack"></param>
        /// <returns>async result use to end request and get result</returns>
        public void DeleteImageByFileAsync(string imageSetId, string filePath,
            Dictionary<string, string> options,
            Action<bool, string> callback) {
            HttpPost hp = ImageSetFileControlP(imageSetId, filePath, "urls_to_delete", options);
            hp.PostAsync(callback);
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
        protected Dictionary<string, string> serviceHeaders(string accessKeyId, string method = "POST") {
            string timeStamp = Functions.getTimeStamp();
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("x-ca-accesskeyid", accessKeyId);
            header.Add("x-ca-version", pAIVersion);
            header.Add("x-ca-timestamp", timeStamp);
            header.Add("x-ca-signaturenonce", Functions.shortUuid());
            header.Add("requestmethod", method);
            header.Add("x-ca-signature", "");
            return header;
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
        protected Dictionary<string, string> getCommonHeader(Dictionary<string, string> parameters) {
            Dictionary<string, string> headers = serviceHeaders(mAccessKeyId);
            string signature = serviceSignature(checkNotExcluded(headers), parameters, mSecretKey);
            headers["x-ca-signature"] = signature;
            return headers;
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
        protected HttpPost SubmitFileToSearchP(string serviceType, string serviceID,
            byte[] fileBytes, Dictionary<string, string> options) {
            string url = urlSearch(serviceType, serviceID);
            Dictionary<string, string> headers = getCommonHeader(options);

            HttpForm form = new HttpForm();
            foreach (var param in options) {
                form.AddField(param.Key, param.Value);
            }
            form.AddBinary("search", fileBytes, "productAIService.jpg", "image/jpegcv");
            HttpPost hp = new HttpPost(url, headers, form);
            return hp;
        }
        protected HttpPost ImageSetFileControlP(
            string imageSetId, string filePath, string ControlStr,
            Dictionary<string, string> options) {
            string postUrl = urlImageSet(imageSetId);
            Dictionary<string, string> headers = getCommonHeader(null);
            HttpForm form = new HttpForm();
            byte[] bytes = Functions.getFileBytes(filePath);
            form.AddBinary(ControlStr, bytes, "productAIService.csv");
            HttpPost hp = new HttpPost(postUrl, headers, form);
            return hp;
        }
        protected HttpPost AddImageToImageSetP(string imageSetId, string imageUrl,
            Dictionary<string, string> options) {
            string postUrl = urlImageSet(imageSetId);
            Dictionary<string, string> parameters =
                new Dictionary<string, string>(options);
            parameters.Add("image_url", imageUrl);
            Dictionary<string, string> headers = getCommonHeader(parameters);
            UrlEncodeForm form = new UrlEncodeForm();
            foreach (var param in parameters) {
                form.AddField(param.Key, param.Value);
            }
            HttpPost hp = new HttpPost(postUrl, headers, form);
            return hp;
        }
        protected HttpPost SubmitFormToSearchP(string serviceType, string serviceID,
            string PictureUrl, Dictionary<string, string> options) {
            string searchUrl = urlSearch(serviceType, serviceID);
            Dictionary<string, string> parameters = new Dictionary<string, string>(options);
            parameters.Add("url", PictureUrl);
            Dictionary<string, string> headers = getCommonHeader(parameters);
            UrlEncodeForm form = new UrlEncodeForm();
            foreach (var param in parameters) {
                form.AddField(param.Key, param.Value);
            }
            HttpPost hp = new HttpPost(searchUrl, headers, form);
            return hp;
        }
    }
}
