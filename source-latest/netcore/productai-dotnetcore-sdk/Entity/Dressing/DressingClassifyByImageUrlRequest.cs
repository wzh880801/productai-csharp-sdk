using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 时尚智能分析
    /// <para>https://api-doc.productai.cn/doc/pai.html#时尚智能分析</para>
    /// </summary>
    public class DressingClassifyByImageUrlRequest 
        : CallApiByImageUrlBaseRequest<DressingClassifyResponse>
    {
        public DressingClassifyByImageUrlRequest(string loc = "0-0-1-1")
            : base("dressing", "_0000057", loc)
        {

        }

        public DressingClassifyByImageUrlRequest(string url, string loc = "0-0-1-1")
            : this(loc)
        {
            this.Url = url;
        }
    }
}