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
        private static Dictionary<int, AIService> _detectServiceDicts = typeof(DetectType).ToServiceDictionary();
        private static Dictionary<int, string> _serviceTypeDicts = typeof(ServiceType).ToDictionary();

        public DetectByImageUrlRequest(DetectType detectType, string loc = "0-0-1-1")
            : base(_detectServiceDicts[(int)detectType].ServiceType,
                  _detectServiceDicts[(int)detectType].ServiceId, loc)
        {

        }

        public DetectByImageUrlRequest(DetectType detectType, string url, string loc = "0-0-1-1")
            : this(detectType, loc)
        {
            this.Url = url;
        }

        public DetectByImageUrlRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public DetectByImageUrlRequest(string serviceType, string serviceId, string url, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.Url = url;
        }

        public DetectByImageUrlRequest(ServiceType serviceType, string serviceId, string loc = "0-0-1-1")
            : base(_serviceTypeDicts[(int)serviceType], serviceId, loc)
        {

        }

        public DetectByImageUrlRequest(ServiceType serviceType, string serviceId, string url, string loc = "0-0-1-1")
            : base(_serviceTypeDicts[(int)serviceType], serviceId, url, loc)
        {

        }
    }
}