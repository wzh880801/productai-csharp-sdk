using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 图像内容分析与标注
    /// </summary>
    public class ClassifyByImageFileRequest
        : CallApiByImageFileBaseRequest<ClassifyResponse>
    {
        public ClassifyByImageFileRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public ClassifyByImageFileRequest(string serviceType, string serviceId, System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.ImageFile = imageFile;
        }
    }
}