using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// Detect by image url
    /// </summary>
    public class DetectByImageUrlRequest
        : CallApiByImageUrlBaseRequest<DetectResponse>
    {
        public DetectByImageUrlRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public DetectByImageUrlRequest(string serviceType, string serviceId, string url, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.Url = url;
        }
    }
}