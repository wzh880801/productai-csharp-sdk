using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 家具与家居用品检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#家具与家居用品检测与定位</para>
    /// </summary>
    public class DetectFurnitureAndHouseholdByImageFileRequest 
        : CallApiByImageFileBaseRequest<DetectResponse>
    {
        public DetectFurnitureAndHouseholdByImageFileRequest(string loc = "0-0-1-1")
            : base("detect_furniture_and_household", "_0000029", loc)
        {

        }

        public DetectFurnitureAndHouseholdByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }
    }
}