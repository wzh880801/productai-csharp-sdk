using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity.Color
{
    public class ColorClassifyByImageUrlRequest
        : CallApiByImageUrlBaseRequest<ColorAnalysisResponse>
    {
        public ColorClassifyByImageUrlRequest(string loc = "0-0-1-1")
            : base("color", "_0000072", loc)
        {

        }

        public ColorClassifyByImageUrlRequest(SubType subType, Granularity granularity, ColorReturnType returnType, string imageUrl, string loc = "0-0-1-1")
            : base("color", "_0000072", loc)
        {
            this.SubType = subType;
            this.Granularity = granularity;
            this.ReturnType = returnType;
            this.Url = imageUrl;
        }

        public ColorClassifyByImageUrlRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : base(serviceType, serviceId, loc)
        {

        }

        public ColorClassifyByImageUrlRequest(string url, string loc = "0-0-1-1")
            : this(loc)
        {
            this.Url = url;
        }

        public ColorClassifyByImageUrlRequest(string serviceType, string serviceId, string url, string loc = "0-0-1-1")
            : base(serviceType, serviceId, url, loc)
        {

        }

        public Core.SubType SubType { get; set; }
        public Core.Granularity Granularity { get; set; }
        public Core.ColorReturnType ReturnType { get; set; }

        private static Dictionary<int, string> _subTypes = typeof(Core.SubType).ToDictionary();
        private static Dictionary<int, string> _granularities = typeof(Core.Granularity).ToDictionary();
        private static Dictionary<int, string> _returnTypes = typeof(Core.ColorReturnType).ToDictionary();

        [Core.ParaSign("sub_type")]
        public string SubTypeString
        {
            get
            {
                return _subTypes[(int)this.SubType];
            }
        }

        [Core.ParaSign("granularity")]
        public string GranularityString
        {
            get
            {
                return _granularities[(int)this.Granularity];
            }
        }

        [Core.ParaSign("return_type")]
        public string ReturnTypeString
        {
            get
            {
                return _returnTypes[(int)this.ReturnType];
            }
        }
    }
}