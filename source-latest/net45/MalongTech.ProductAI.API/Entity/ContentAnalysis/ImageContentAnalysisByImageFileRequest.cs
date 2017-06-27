using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 通用图片内容分析与标注
    /// <para>https://api-doc.productai.cn/doc/pai.html#通用图片内容分析与标注</para>
    /// </summary>
    public class ImageContentAnalysisByImageFileRequest 
        : CallApiByImageFileBaseRequest<ImageContentAnalysisResponse>
    {
        public ImageContentAnalysisByImageFileRequest(string loc = "0-0-1-1")
            : base("classify_general", "_0000044", loc)
        {

        }

        public ImageContentAnalysisByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }
    }
}