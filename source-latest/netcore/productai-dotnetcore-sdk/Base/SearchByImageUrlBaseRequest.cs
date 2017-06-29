using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API
{
    public abstract class SearchByImageUrlBaseRequest<T> : CallApiByImageUrlBaseRequest<T>
        where T : BaseResponse
    {
        public SearchByImageUrlBaseRequest(string serviceType, string serviceId)
            : base(serviceType, serviceId)
        {

        }

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
        }

        [ParaSign("count")]
        public int? Count { get; set; }

        public SearchByImageUrlBaseRequest(string serviceType, string serviceId, string loc = "0-0-1-1", ITag searchTag = null, int? count = null)
            : this(serviceType, serviceId)
        {
            this.Loc = loc;
            this.SearchTag = searchTag;
            this.Count = count;
        }

        public SearchByImageUrlBaseRequest(string serviceType, string serviceId, string url, string loc = "0-0-1-1", ITag searchTag = null, int? count = null)
            : this(serviceType, serviceId, loc, searchTag, count)
        {
            this.Url = url;
        }
    }
}