using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class SearchTaskResponse : Core.BaseResponse
    {
        [JsonProperty("data")]
        public Dictionary<string, TaskDetailInfo> Tasks { get; set; }
    }
}
