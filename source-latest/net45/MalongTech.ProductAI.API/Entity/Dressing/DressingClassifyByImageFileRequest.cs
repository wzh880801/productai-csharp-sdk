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
            : base("dressing", "_0000111", loc)
        {

        }

        public DressingClassifyByImageFileRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public DressingClassifyByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }

        public DressingClassifyByImageFileRequest(string serviceType, string serviceId, System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : base(serviceType, serviceId, imageFile, loc)
        {

        }
    }
}