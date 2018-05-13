using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// Detect by image file
    /// </summary>
    public class DetectByImageStreamRequest
        : CallApiByImageStreamBaseRequest<DetectResponse>
    {
        public DetectByImageStreamRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public DetectByImageStreamRequest(string serviceType, string serviceId, System.IO.Stream imageStream, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.ImageStream = imageStream;
        }
    }
}