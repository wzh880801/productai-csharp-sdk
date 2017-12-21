using System;
using System.Collections.Generic;

namespace MalongTech.ProductAI.API.Entity
{
    /// <summary>
    /// 向数据集增加单条数据
    /// <para>https://api-doc.productai.cn/doc/pai.html#向数据集增加单条数据</para>
    /// </summary>
    public class DataSetSingleAddByImageUrlRequest
        : DataSetSingleModifyByUrlBaseRequest<DataSetBaseResponse>
    {
        public DataSetSingleAddByImageUrlRequest(string imageSetId, List<string> tags = null, string metaId = null)
            : base(imageSetId, tags, metaId)
        {

        }

        public DataSetSingleAddByImageUrlRequest(string imageSetId, string imageUrl, List<string> tags = null, string metaId = null)
            : this(imageSetId, tags, metaId)
        {
            this.ImageUrl = imageUrl;
        }
    }
}