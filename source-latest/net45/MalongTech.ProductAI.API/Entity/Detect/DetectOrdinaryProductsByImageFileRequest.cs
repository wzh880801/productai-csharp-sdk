using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 常见商品检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#常见商品检测与定位</para>
    /// </summary>
    public class DetectOrdinaryProductsByImageFileRequest 
        : CallApiByImageFileBaseRequest<DetectResponse>
    {
        public DetectOrdinaryProductsByImageFileRequest(string loc = "0-0-1-1")
            : base("detect_ordinary_products", "_0000030", loc)
        {

        }

        public DetectOrdinaryProductsByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }
    }
}