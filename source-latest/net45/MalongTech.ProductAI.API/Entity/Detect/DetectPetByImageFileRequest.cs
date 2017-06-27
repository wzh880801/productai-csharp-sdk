using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 宠物检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#宠物检测与定位</para>
    /// </summary>
    public class DetectPetByImageFileRequest 
        : CallApiByImageFileBaseRequest<DetectResponse>
    {
        public DetectPetByImageFileRequest(string loc = "0-0-1-1")
            : base("detect_pet", "_0000031", loc)
        {

        }

        public DetectPetByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }
    }
}