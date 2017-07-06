using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// Detect by image file
    /// </summary>
    public class DetectByImageFileRequest
        : CallApiByImageFileBaseRequest<DetectResponse>
    {
        private static Dictionary<int, AIService> _detectServiceDicts = typeof(DetectType).ToServiceDictionary();
        private static Dictionary<int, string> _serviceTypeDicts = typeof(ServiceType).ToDictionary();

        public DetectByImageFileRequest(DetectType detectType, string loc = "0-0-1-1")
            : base(_detectServiceDicts[(int)detectType].ServiceType,
                  _detectServiceDicts[(int)detectType].ServiceId, loc)
        {

        }

        public DetectByImageFileRequest(DetectType detectType, System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(detectType, loc)
        {
            this.ImageFile = imageFile;
        }

        public DetectByImageFileRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public DetectByImageFileRequest(string serviceType, string serviceId, System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.ImageFile = imageFile;
        }

        public DetectByImageFileRequest(string serviceId, ServiceType serviceType = ServiceType.Detect, string loc = "0-0-1-1")
            : base(_serviceTypeDicts[(int)serviceType], serviceId, loc)
        {

        }

        public DetectByImageFileRequest(string serviceId, System.IO.FileInfo imageFile, ServiceType serviceType = ServiceType.Detect, string loc = "0-0-1-1")
            : this(_serviceTypeDicts[(int)serviceType], serviceId, loc)
        {
            this.ImageFile = imageFile;
        }
    }
}