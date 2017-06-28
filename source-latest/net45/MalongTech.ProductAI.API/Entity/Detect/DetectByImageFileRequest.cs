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
    }
}