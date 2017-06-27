using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 食品检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#食品检测与定位</para>
    /// </summary>
    public class DetectFoodByImageFileRequest 
        : CallApiByImageFileBaseRequest<DetectResponse>
    {
        public DetectFoodByImageFileRequest(string loc = "0-0-1-1")
            : base("detect_food", "detect_food", loc)
        {

        }

        public DetectFoodByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }
    }
}