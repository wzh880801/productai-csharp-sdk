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
        private static Dictionary<int, AIService> _classifyServiceDicts = typeof(ClassifyType).ToServiceDictionary();
        private static Dictionary<int, string> _serviceTypeDicts = typeof(ServiceType).ToDictionary();

        public ClassifyByImageFileRequest(ClassifyType classifyType, string loc = "0-0-1-1")
            : base(_classifyServiceDicts[(int)classifyType].ServiceType,
                _classifyServiceDicts[(int)classifyType].ServiceId, loc)
        {

        }

        public ClassifyByImageFileRequest(ClassifyType classifyType, System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(classifyType, loc)
        {
            this.ImageFile = imageFile;
        }

        public ClassifyByImageFileRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public ClassifyByImageFileRequest(string serviceType, string serviceId, System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.ImageFile = imageFile;
        }

        public ClassifyByImageFileRequest(ServiceType serviceType, string serviceId, string loc = "0-0-1-1")
            : base(_serviceTypeDicts[(int)serviceType], serviceId, loc)
        {

        }

        public ClassifyByImageFileRequest(ServiceType serviceType, string serviceId, System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(_serviceTypeDicts[(int)serviceType], serviceId, loc)
        {
            this.ImageFile = imageFile;
        }
    }
}