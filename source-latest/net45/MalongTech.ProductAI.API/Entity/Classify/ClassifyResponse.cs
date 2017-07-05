using System;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassifyResponse : BaseResponse
    {
        [JsonProperty("results")]
        public ClassifyResult[] Results { get; set; }   
    }
}