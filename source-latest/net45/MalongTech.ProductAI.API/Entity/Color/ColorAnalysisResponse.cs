using System;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity.Color
{
    public class ColorAnalysisResponse : BaseResponse
    {
        [JsonProperty("results")]
        public ColorAnalysisResult[] Results { get; set; }
    }

    public class ColorAnalysisResult
    {
        /// <summary>
        /// cncs相关结果信息
        /// </summary>
        [JsonProperty("cncs")]
        public CNCS CNCS { get; set; }

        /// <summary>
        /// 基础颜色结果信息
        /// </summary>
        [JsonProperty("basic")]
        public string Basic { get; set; }

        /// <summary>
        /// w3c标准的结果信息
        /// </summary>
        [JsonProperty("w3c")]
        public string W3C { get; set; }

        /// <summary>
        /// ncs相关结果信息
        /// </summary>
        [JsonProperty("ncs")]
        public string NCS { get; set; }

        /// <summary>
        /// 颜色比例
        /// </summary>
        [JsonProperty("freq")]
        public float Percent { get; set; }

        /// <summary>
        /// 16进制颜色码
        /// </summary>
        [JsonProperty("hex")]
        public string HEX { get; set; }

        /// <summary>
        /// RGB颜色码
        /// </summary>
        [JsonProperty("rgb")]
        public int[] RGB { get; set; }
    }

    /// <summary>
    /// cncs相关结果信息
    /// </summary>
    public class CNCS
    {
        [JsonProperty("chroma")]
        public string Chroma { get; set; }

        [JsonProperty("cncs")]
        public string Cncs { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("lightness")]
        public string Lightness { get; set; }

        [JsonProperty("rgb")]
        public int[] RGB { get; set; }
    }
}