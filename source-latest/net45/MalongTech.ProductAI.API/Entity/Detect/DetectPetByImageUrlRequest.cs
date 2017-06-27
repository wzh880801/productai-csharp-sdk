using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 宠物检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#宠物检测与定位</para>
    /// </summary>
    public class DetectPetByImageUrlRequest 
        : CallApiByImageUrlBaseRequest<DetectResponse>
    {
        public DetectPetByImageUrlRequest(string loc = "0-0-1-1")
            : base("detect_pet", "_0000031", loc)
        {

        }

        public DetectPetByImageUrlRequest(string url, string loc = "0-0-1-1")
            : this(loc)
        {
            this.Url = url;
        }
    }
}