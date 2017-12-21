using System;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    public class DressingClassifyResponse : BaseResponse
    {
        [JsonProperty("results")]
        public DressingClassifyResult[] Results { get; set; }

        [JsonProperty("labels")]
        public string[] Labels { get; set; }

        [JsonProperty("labels-en")]
        public string[] LabelsEN { get; set; }
    }
}