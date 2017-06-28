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

        public List<string> SearchTags { get; set; }

        [ParaSign("tags", true)]
        public string Tags
        {
            get
            {
                if (this.SearchTags == null || this.SearchTags.Count == 0)
                    return null;

                return string.Join("|", this.SearchTags);
            }
        }

        [ParaSign("count")]
        public int? Count { get; set; }

        public SearchByImageUrlBaseRequest(string serviceType, string serviceId, string loc = "0-0-1-1", List<string> tags = null, int? count = null)
            : this(serviceType, serviceId)
        {
            this.Loc = loc;
            this.SearchTags = tags;
            this.Count = count;
        }

        public SearchByImageUrlBaseRequest(string serviceType, string serviceId, string url, string loc = "0-0-1-1", List<string> tags = null, int? count = null)
            : this(serviceType, serviceId, loc, tags, count)
        {
            this.Url = url;
        }
    }
}