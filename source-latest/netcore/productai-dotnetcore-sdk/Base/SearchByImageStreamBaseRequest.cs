using System;
using System.IO;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API
{
    public abstract class SearchByImageStreamBaseRequest<T> : CallApiByImageStreamBaseRequest<T>
        where T : BaseResponse
    {
        /// <summary>
        /// 搜索标签
        /// </summary>
        public ITag SearchTag { get; set; }

        [ParaSign("tags", true)]
        public string Tags
        {
            get
            {
                if (this.SearchTag != null)
                    return this.SearchTag.ToString();

                return null;
            }

            /*
                {
                    "and": [
                        "上衣",
                        {
                            "or": [
                                "蓝色",
                                "休闲"
                            ]
                        }
                    ]
                }
             * 
             */
        }

        [ParaSign("count")]
        public int? Count { get; set; }

        public SearchByImageStreamBaseRequest(string serviceType, string serviceId)
            : base(serviceType, serviceId)
        {

        }

        public SearchByImageStreamBaseRequest(string serviceType, string serviceId, string loc = "0-0-1-1", ITag searchTag = null, int? count = null)
            : this(serviceType, serviceId)
        {
            this.Loc = loc;
            this.SearchTag = searchTag;
            this.Count = count;
        }

        public SearchByImageStreamBaseRequest(string serviceType, string serviceId, Stream imageStream, string loc = "0-0-1-1", ITag searchTag = null, int? count = null)
            : this(serviceType, serviceId, loc, searchTag, count)
        {
            this.ImageStream = imageStream;
        }
    }
}