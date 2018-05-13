using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 图像内容分析与标注
    /// </summary>
    public class ClassifyByImageStreamRequest
        : CallApiByImageStreamBaseRequest<ClassifyResponse>
    {
        public ClassifyByImageStreamRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public ClassifyByImageStreamRequest(string serviceType, string serviceId, System.IO.Stream imageStream, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.ImageStream = imageStream;
        }
    }
}