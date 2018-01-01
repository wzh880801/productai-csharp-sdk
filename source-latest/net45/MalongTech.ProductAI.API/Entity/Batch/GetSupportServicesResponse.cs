using System;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class GetSupportServicesResponse : Core.BaseResponse
    {
        [JsonProperty("data")]
        public string[] SupportServiceIds { get; set; }
    }
}
