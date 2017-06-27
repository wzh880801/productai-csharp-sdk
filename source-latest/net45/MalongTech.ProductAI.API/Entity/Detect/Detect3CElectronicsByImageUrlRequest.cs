using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 3C电器检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#3C电器检测与定位</para>
    /// </summary>
    public class Detect3CElectronicsByImageUrlRequest 
        : CallApiByImageUrlBaseRequest<DetectResponse>
    {
        public Detect3CElectronicsByImageUrlRequest(string loc = "0-0-1-1")
            : base("detect_3c_and_electronics", "_0000027", loc)
        {
            
        }

        public Detect3CElectronicsByImageUrlRequest(string url, string loc = "0-0-1-1")
            : this(loc)
        {
            this.Url = url;
        }
    }
}