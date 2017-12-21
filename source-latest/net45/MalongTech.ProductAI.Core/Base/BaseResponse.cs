using System;
using System.Net;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.Core
{
    public abstract class BaseResponse
    {
        public virtual ResponseType ResponseType { get; } = ResponseType.Json;

        /// <summary>
        /// the json string returned in Base64String
        /// </summary>
        public virtual string ResponseBase64String { get; set; }

        /// <summary>
        /// the json string returned
        /// </summary>
        public virtual string ResponseJsonString
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.ResponseBase64String))
                    return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(this.ResponseBase64String));

                return null;
            }
        }

        [JsonIgnore]
        public virtual WebHeaderCollection Headers { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// <para>0 - Succeed</para>
        /// </summary>
        [JsonProperty("is_err")]
        public int IsError { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        [JsonProperty("err_msg")]
        public string ErrorMsg { get; set; }

        /// <summary>
        /// Time cost
        /// </summary>
        [JsonProperty("time")]
        public decimal Time { get; set; }

        [JsonProperty("time_detail")]
        public decimal[] TimeDetails { get; set; }

        /// <summary>
        /// Unique request id
        /// 本次调用的唯一ID，可以用于和ProductAI团队进行联调分析
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// error code
        /// </summary>
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// error message info
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("ver")]
        public string Version { get; set; }
    }
}