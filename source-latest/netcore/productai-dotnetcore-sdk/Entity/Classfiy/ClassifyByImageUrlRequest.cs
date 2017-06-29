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
    }
}