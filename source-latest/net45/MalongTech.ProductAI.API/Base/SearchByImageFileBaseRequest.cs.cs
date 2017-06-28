using System;
using System.IO;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API
{
    public abstract class SearchByImageFileBaseRequest<T> : CallApiByImageFileBaseRequest<T>
        where T : BaseResponse
    {
        /// <summary>
        /// 简单Tag
        /// 和SearchTag二选一，如果二者都设置了值，则忽略此值
        /// </summary>
        public List<string> SearchTags { get; set; }

        /// <summary>
        /// 复杂Tag
        /// 和SearchTags二选一，如果二者都设置了值，则使用此值
        /// </summary>
        public ITag SearchTag { get; set; }

        [ParaSign("tags", true)]
        public string Tags
        {
            get
            {
                if (this.SearchTag != null)
                    return this.SearchTag.ToString();

                if (this.SearchTags == null || this.SearchTags.Count == 0)
                    return null;

                return string.Join("|", this.SearchTags);
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

        public SearchByImageFileBaseRequest(string serviceType, string serviceId)
            : base(serviceType, serviceId)
        {

        }

        public SearchByImageFileBaseRequest(string serviceType, string serviceId, string loc = "0-0-1-1", List<string> tags = null, int? count = null)
            : this(serviceType, serviceId)
        {
            this.Loc = loc;
            this.SearchTags = tags;
            this.Count = count;
        }

        public SearchByImageFileBaseRequest(string serviceType, string serviceId, FileInfo imageFile, string loc = "0-0-1-1", List<string> tags = null, int? count = null)
            : this(serviceType, serviceId, loc, tags, count)
        {
            this.ImageFile = imageFile;
        }
    }
}