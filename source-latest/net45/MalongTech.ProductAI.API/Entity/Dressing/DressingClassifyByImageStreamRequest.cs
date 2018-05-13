using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 时尚智能分析
    /// <para>https://api-doc.productai.cn/doc/pai.html#时尚智能分析</para>
    /// </summary>
    public class DressingClassifyByImageStreamRequest
        : CallApiByImageStreamBaseRequest<DressingClassifyResponse>
    {
        public DressingClassifyByImageStreamRequest(string loc = "0-0-1-1")
            : base("dressing", "_0000111", loc)
        {

        }

        public DressingClassifyByImageStreamRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public DressingClassifyByImageStreamRequest(System.IO.Stream imageStream, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageStream = imageStream;
        }

        public DressingClassifyByImageStreamRequest(string serviceType, string serviceId, System.IO.Stream imageStream, string loc = "0-0-1-1")
            : base(serviceType, serviceId, imageStream, loc)
        {

        }
    }
}