using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 服装检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#服装检测与定位</para>
    /// </summary>
    public class DetectClothByImageFileRequest 
        : CallApiByImageFileBaseRequest<DetectResponse>
    {
        public DetectClothByImageFileRequest(string loc = "0-0-1-1")
            : base("detect_cloth", "_0000025", loc)
        {

        }

        public DetectClothByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }
    }
}