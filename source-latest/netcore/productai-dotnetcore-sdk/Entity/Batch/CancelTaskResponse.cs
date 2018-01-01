using System;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class CancelTaskResponse : Core.BaseResponse
    {
        [JsonProperty("data")]
        public CancelTaskResult Result { get; set; }
    }

    public class CancelTaskResult
    {
        /// <summary>
        /// 取消成功后，总是返回200001
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// 目前总是返回任务ID
        /// </summary>
        [JsonProperty("args")]
        public string[] Args { get; set; }
    }
}
