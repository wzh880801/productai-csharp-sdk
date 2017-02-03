using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Net;
using System.IO;

namespace ProductAI.API {
    public abstract class IForms {
        public abstract byte[] GetData();
        public string ContentType {
            get;
            protected set;
        }
    }

    public class HttpForm: IForms {
        protected string        boundary;
        protected byte[]        binaryBytes;

        protected Dictionary<string,string> fieldEntities = new Dictionary<string, string>();
        protected List<byte[]> fileEntities =new List<byte[]>();
  
        public override byte[] GetData() {
            List<byte[]> datas = new List<byte[]>();
            foreach (var fldEnt in fieldEntities) {
                datas.Add(fieldBytes(fldEnt.Key, fldEnt.Value));
            }
            foreach (var flEnt in fileEntities) {
                datas.Add(flEnt);
            }
            datas.Add(tailBytes());
            return mergeBytes(datas);
        }
        public HttpForm() {
            boundary = "---------------------------" +
                DateTime.Now.Ticks.ToString("x");
            ContentType = "multipart/form-data; boundary="
                    + boundary;
        }
        protected byte[] boundaryBytes() {
            return Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
        }
        protected byte[] fileHeaders(string name, string fileName, string fileContentType) {
            string header = "Content-Disposition: form-data;";
            header += string.Format(" name=\"{0}\";", name);
            header += string.Format(" filename=\"{0}\"\r\n", fileName);
            header += string.Format("Content-Type: {0}\r\n\r\n", fileContentType);
            return Encoding.UTF8.GetBytes(header);
        }
        protected byte[] fieldBytes(string key, string value) {
            string field = "Content-Disposition: form-data;";
            field += string.Format(" name=\"{0}\"\r\n\r\n{1}", key, value);
            byte[] fdBytes = Encoding.UTF8.GetBytes(field);
            byte[] bdBytes = boundaryBytes();
            return mergeBytes(new List<byte[]> { bdBytes, fdBytes });//此处又修改   少加了一个boundar
        }
        protected byte[] tailBytes() {
            string tail = string.Format("\r\n--{0}--\r\n", boundary);
            return Encoding.UTF8.GetBytes(tail);
        }
        protected int byteCounts(List<byte[]> bsList) {
            int bsLength = 0;
            foreach (var bs in bsList) {
                bsLength += bs.Length;
            }
            return bsLength;
        }
        protected byte[] mergeBytes(List<byte[]> bsList) {
            int bsLength = byteCounts(bsList);
            int bsMerged = 0;

            byte[] res = new byte[bsLength];
            foreach (var bs in bsList) {
                bs.CopyTo(res, bsMerged);
                bsMerged += bs.Length;
            }
            return res;
        }
        public void AddBinary(string name, byte[] data,
            string fileName = "",
            string fileContentType = "") {
            byte[] bdBytes = boundaryBytes();
            byte[] hdBytes = fileHeaders(name, fileName, fileContentType);
            fileEntities.Add(
                mergeBytes(new List<byte[]>() { bdBytes, hdBytes, data })
                );
        }
        public void AddField(string fieldName, string value) {
            fieldEntities.Add(fieldName, value);
        }
    };

    public class UrlEncodeForm: IForms {
        protected Dictionary<string,string> fields=
            new Dictionary<string, string>();
        protected virtual List<string> urlFieldPair(){
            List<string> res = new List<string>();
            foreach (var field in fields) {
                string key = field.Key;
                string value = field.Value;
                key = Uri.EscapeDataString(key);
                value = Uri.EscapeDataString(value);
                res.Add(key + "=" + value);
            }
            return res;
        }
        protected virtual string MergeUrlPair() {
            List<string> rsStr = urlFieldPair();
            StringBuilder sb = new StringBuilder();
            sb.Append(rsStr[0]);
            for (int i = 1; i < rsStr.Count; i++) {
                sb.Append("&" + rsStr[i]);
            }
            return sb.ToString();
        }
        public UrlEncodeForm() {
            ContentType = "application/x-www-form-urlencoded";
        }
        public override byte[] GetData() {
            string urlEscString = MergeUrlPair();
            return Encoding.UTF8.GetBytes(urlEscString);
        }
        public void AddField(string fieldName, string value) {
            fields.Add(fieldName, value);
        }
    }

    public class HttpPost{
        protected HttpWebRequest wr;
        protected IForms  mForm;
        protected Action<bool,string> mCallback;
        public string ResultText {
            get;
            protected set;
        }
        public bool IsError {
            get;
            protected set;
        }
        public  HttpPost(string url,Dictionary<string,string> headers,IForms form) {
            wr = WebRequest.Create(url) as HttpWebRequest;
            wr.Method = "POST";
            wr.KeepAlive = true;
            wr.Timeout = 20 * 1000;
            wr.Credentials = CredentialCache.DefaultCredentials;
            if (null != headers) {
                foreach (var header in headers) {
                    wr.Headers.Add(header.Key,header.Value);        
                }
            }
            mForm = form;
            ResultText = "";
            IsError = false;
        }
        public void requestCallback(IAsyncResult ar) {
            try {
                Stream stream = wr.EndGetRequestStream(ar);
                writeStream(stream);
                stream.Close();
                wr.BeginGetResponse(responseCallback,this);
            } catch (WebException ex) {
                IsError = true;
                ResultText = ex.Message;
                if (null != mCallback) {
                    mCallback(IsError, ResultText);
                }
            }
        }
        public void responseCallback(IAsyncResult ar) {
            try {
                WebResponse resp = wr.EndGetResponse(ar);
                ReadResponse(resp);
                if (null != mCallback) {
                    mCallback(IsError, ResultText);
                }
            } catch(WebException ex) {
                ErrorResult(ex);
                if (null != mCallback) {
                    mCallback(IsError, ResultText);
                }
            }  
        }
        public void Post() {
            wr.ContentType = mForm.ContentType;
            try {
                using (Stream stream = wr.GetRequestStream()) {
                    writeStream(stream);
                }
            } catch (WebException ex) {
                IsError = true;
                ResultText = ex.Message;
            }
            if (!IsError ) {
                GetRespResult();
            }
        }
        public void PostAsync(Action<bool,string> callback) {
            mCallback = callback;
            wr.ContentType = mForm.ContentType;
            try {
                wr.BeginGetRequestStream(requestCallback, this);
            } catch (WebException ex) {
                IsError = true;
                ResultText = ex.Message;
               if(null != callback){
                    callback(IsError, ResultText);
                }
            }
        }
        protected void ErrorResult(WebException ex) {
            IsError = true;
            string errStr = ex.Message;
            if (null != ex.Response) {
                ReadResponse(ex.Response);
                ResultText = errStr + "\r\n" + ResultText;
            }
        }
        protected void writeStream(Stream stream) {
            byte[] formData = mForm.GetData();
            stream.Write(formData, 0, formData.Length);
        }
        protected void ReadResponse(WebResponse resp) {
            using (Stream stream = resp.GetResponseStream()) {
                StreamReader reader = new StreamReader(stream);
                ResultText = reader.ReadToEnd();
            }
        }
        protected void GetRespResult() {
            try {
                WebResponse resp = wr.GetResponse();
                ReadResponse(resp);
            } catch (WebException ex) {
                ErrorResult(ex);
            }
        }
    }

    public class SignatureBytes: UrlEncodeForm {
        protected override List<string> urlFieldPair() {
            List<string> res = new List<string>();
            Dictionary<string, string> SortedFields =
                fields.OrderBy(x => x.Key).ToDictionary(item => item.Key,item=>item.Value);
            foreach (var field in SortedFields) {
                string key = field.Key;
                string value = field.Value;
                res.Add(key + "=" + value);
            }
            return res;
        }
    }
}
