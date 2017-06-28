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
    }
}