using System;
using System.Collections.Generic;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 图像搜索
    /// <para>https://api-doc.productai.cn/doc/pai.html#创意图像精准匹配</para>
    /// </summary>
    public class ImageSearchByImageUrlRequest 
        : SearchByImageUrlBaseRequest<ImageSearchResponse>
    {
        public ImageSearchByImageUrlRequest(string serviceId, string loc = "0-0-1-1", List<string> tags = null, int? count = null)
            : base("search", serviceId, loc, tags, count)
        {
            
        }

        public ImageSearchByImageUrlRequest(string serviceId, string url, string loc = "0-0-1-1", List<string> tags = null, int? count = null)
            : this(serviceId, loc, tags, count)
        {
            this.Url = url;
        }
    }
}