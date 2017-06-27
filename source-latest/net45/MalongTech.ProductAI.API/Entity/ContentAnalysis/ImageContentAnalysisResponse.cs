using System;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 通用图片内容分析与标注
    /// <para>https://api-doc.productai.cn/doc/pai.html#通用图片内容分析与标注</para>
    /// </summary>
    public class ImageContentAnalysisResponse : BaseResponse
    {
        [JsonProperty("results")]
        public ImageContentAnalysisResult[] Results { get; set; }   
    }
}