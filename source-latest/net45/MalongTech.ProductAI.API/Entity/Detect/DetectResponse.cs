using System;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    public class DetectResponse : BaseResponse
    {
        [JsonProperty("boxes_detected")]
        public DetectResult[] DetectedBoxes { get; set; }

        [JsonProperty("detecttime")]
        public double DetectTime { get; set; }
    }
}