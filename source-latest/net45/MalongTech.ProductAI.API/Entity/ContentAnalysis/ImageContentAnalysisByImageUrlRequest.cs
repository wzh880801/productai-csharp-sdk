using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 通用图片内容分析与标注
    /// <para>https://api-doc.productai.cn/doc/pai.html#通用图片内容分析与标注</para>
    /// </summary>
    public class ImageContentAnalysisByImageUrlRequest 
        : CallApiByImageUrlBaseRequest<ImageContentAnalysisResponse>
    {
        public ImageContentAnalysisByImageUrlRequest(string loc = "0-0-1-1")
            : base("classify_general", "_0000044", loc)
        {

        }

        public ImageContentAnalysisByImageUrlRequest(string url, string loc = "0-0-1-1")
            : this(loc)
        {
            this.Url = url;
        }
    }
}