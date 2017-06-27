using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 食品检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#食品检测与定位</para>
    /// </summary>
    public class DetectFoodByImageUrlRequest 
        : CallApiByImageUrlBaseRequest<DetectResponse>
    {
        public DetectFoodByImageUrlRequest(string loc = "0-0-1-1")
            : base("detect_food", "_0000028", loc)
        {

        }

        public DetectFoodByImageUrlRequest(string url, string loc = "0-0-1-1")
            : this(loc)
        {
            this.Url = url;
        }
    }
}