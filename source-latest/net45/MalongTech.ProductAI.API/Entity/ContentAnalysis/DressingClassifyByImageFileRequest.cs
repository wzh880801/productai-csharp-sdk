using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 时尚智能分析
    /// <para>https://api-doc.productai.cn/doc/pai.html#时尚智能分析</para>
    /// </summary>
    public class DressingClassifyByImageFileRequest 
        : CallApiByImageFileBaseRequest<DressingClassifyResponse>
    {
        public DressingClassifyByImageFileRequest(string loc = "0-0-1-1")
            : base("classify_dressing", "_0000057", loc)
        {

        }

        public DressingClassifyByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }
    }
}