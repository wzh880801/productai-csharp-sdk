using System;
using System.Net;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.Core
{
    public abstract class BaseResponse
    {
        public virtual ResponseType ResponseType { get; } = ResponseType.Json;

        public virtual string ResponseBase64String { get; set; }

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