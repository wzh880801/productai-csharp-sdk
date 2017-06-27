using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 家具与家居用品检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#家具与家居用品检测与定位</para>
    /// </summary>
    public class DetectFurnitureAndHouseholdByImageUrlRequest 
        : CallApiByImageUrlBaseRequest<DetectResponse>
    {
        public DetectFurnitureAndHouseholdByImageUrlRequest(string loc = "0-0-1-1")
            : base("detect_pet", "_0000031", loc)
        {

        }

        public DetectFurnitureAndHouseholdByImageUrlRequest(string url, string loc = "0-0-1-1")
            : this(loc)
        {
            this.Url = url;
        }
    }
}