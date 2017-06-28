using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace MalongTech.ProductAI.Core
{
    internal class HttpResponse
    {
        public string ResposeString
        {
            get
            {
                if (this.ResponseBytes == null || this.ResponseBytes.Length == 0)
                    return null;
                return Encoding.UTF8.GetString(this.ResponseBytes);
            }
        }
        public byte[] ResponseBytes { get; set; }

        public WebHeaderCollection Headers { get; private set; }
        public string CharacterSet { get; private set; }
        public string ContentEncoding { get; private set; }
        public long ContentLength { get; private set; }
        public string ContentType { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public string StatusDescription { get; private set; }

        public HttpResponse(HttpWebResponse response)
        {
            this.Headers = response.Headers;
            this.CharacterSet = response.CharacterSet;
            this.ContentEncoding = response.ContentEncoding;
            this.ContentLength = response.ContentLength;
            this.ContentType = response.ContentType;
            this.StatusCode = response.StatusCode;
            this.StatusDescription = response.StatusDescription;
        }
    }
}