using System;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 交通工具检测与定位
    /// <para>https://api-doc.productai.cn/doc/pai.html#交通工具检测与定位</para>
    /// </summary>
    public class DetectVehicleByImageFileRequest 
        : CallApiByImageFileBaseRequest<DetectResponse>
    {
        public DetectVehicleByImageFileRequest(string loc = "0-0-1-1")
            : base("detect_vehicle", "_0000033", loc)
        {

        }

        public DetectVehicleByImageFileRequest(System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(loc)
        {
            this.ImageFile = imageFile;
        }
    }
}