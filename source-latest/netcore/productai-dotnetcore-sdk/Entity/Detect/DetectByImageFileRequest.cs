﻿using System;
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
        public DetectByImageFileRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public DetectByImageFileRequest(string serviceType, string serviceId, System.IO.FileInfo imageFile, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.ImageFile = imageFile;
        }
    }
}