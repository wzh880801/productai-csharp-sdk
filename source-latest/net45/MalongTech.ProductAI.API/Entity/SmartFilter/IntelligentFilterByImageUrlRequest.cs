using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 智能滤镜
    /// <para>https://api-doc.productai.cn/doc/pai.html#智能滤镜</para>
    /// </summary>
    public class IntelligentFilterByImageUrlRequest 
        : CallApiByImageUrlBaseRequest<IntelligentFilterResponse>
    {
        public IntelligentFilterByImageUrlRequest(string loc = "0-0-1-1")
            : base("filter", "_0000015")
        {
            this.Loc = loc;
        }

        public IntelligentFilterByImageUrlRequest(string url, string loc = "0-0-1-1")
            : this(loc)
        {
            this.Url = url;
        }
    }
}