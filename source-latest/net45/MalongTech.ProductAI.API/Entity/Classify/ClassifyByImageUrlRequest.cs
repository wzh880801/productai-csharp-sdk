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
        private static Dictionary<int, AIService> _classifyServiceDicts = typeof(ClassifyType).ToServiceDictionary();
        private static Dictionary<int, string> _serviceTypeDicts = typeof(ServiceType).ToDictionary();

        public ClassifyByImageUrlRequest(ClassifyType classifyType, string loc = "0-0-1-1")
            : base(_classifyServiceDicts[(int)classifyType].ServiceType,
                  _classifyServiceDicts[(int)classifyType].ServiceId, loc)
        {

        }

        public ClassifyByImageUrlRequest(ClassifyType classifyType, string url, string loc = "0-0-1-1")
            : this(classifyType, loc)
        {
            this.Url = url;
        }

        public ClassifyByImageUrlRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public ClassifyByImageUrlRequest(string serviceType, string serviceId, string url, string loc = "0-0-1-1")
            : base(serviceType, serviceId, url, loc)
        {

        }

        public ClassifyByImageUrlRequest(string serviceId, ServiceType serviceType = ServiceType.Classify, string loc = "0-0-1-1")
            : base(_serviceTypeDicts[(int)serviceType], serviceId, loc)
        {

        }

        public ClassifyByImageUrlRequest(string serviceId, string url, ServiceType serviceType = ServiceType.Classify, string loc = "0-0-1-1")
            : base(_serviceTypeDicts[(int)serviceType], serviceId, url, loc)
        {

        }
    }
}