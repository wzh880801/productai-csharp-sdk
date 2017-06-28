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
    }
}