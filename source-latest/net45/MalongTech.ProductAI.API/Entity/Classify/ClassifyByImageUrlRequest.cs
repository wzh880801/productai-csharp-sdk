using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassifyByImageUrlRequest
        : CallApiByImageUrlBaseRequest<ClassifyResponse>
    {
        public ClassifyByImageUrlRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public ClassifyByImageUrlRequest(string serviceType, string serviceId, string url, string loc = "0-0-1-1")
            : base(serviceType, serviceId, url, loc)
        {

        }
    }
}