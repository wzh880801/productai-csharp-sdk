using System;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    public class IntelligentFilterResponse : BaseResponse
    {
        [JsonProperty("results")]
        public IntelligentFilterResult[] Results { get; set; }

        [JsonProperty("content_img")]
        public string ContentImgUrl { get; set; }

        [JsonProperty("style_img")]
        public string StyleImgPath { get; set; }
    }
}