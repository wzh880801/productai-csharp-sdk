using System;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.API.Entity
{
    public class ClassifyResult
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("score")]
        public decimal Score { get; set; }
    }
}