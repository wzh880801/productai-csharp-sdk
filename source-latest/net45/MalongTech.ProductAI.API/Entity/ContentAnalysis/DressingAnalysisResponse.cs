using System;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    public class DressingAnalysisResponse : BaseResponse
    {
        [JsonProperty("results")]
        public DressingAnalysisResult[] Results { get; set; }
    }
}