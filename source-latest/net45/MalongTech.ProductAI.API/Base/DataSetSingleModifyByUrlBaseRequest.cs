using System;
using System.Collections.Generic;
using System.Reflection;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API
{
    [IgnoreExtraParas]
    public abstract class DataSetSingleModifyByUrlBaseRequest<T> : BaseRequest<T>
        where T : BaseResponse
    {
        private string _imageSetId = "";

        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/image_sets/_0000014/{1}", this.Host, this._imageSetId);
            }
        }

        [ParaSign("image_url", true)]
        public string ImageUrl { get; set; }

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

        [ParaSign("meta")]
        public string Meta { get; set; }

        public DataSetSingleModifyByUrlBaseRequest(string imageSetId, List<string> tags = null, string meta = null)
        : base()
        {
            if (string.IsNullOrWhiteSpace(imageSetId))
                throw new ArgumentNullException(nameof(imageSetId));

            this._imageSetId = imageSetId;
            this.SearchTags = tags;
            this.Meta = meta;
        }

        public DataSetSingleModifyByUrlBaseRequest(string imageSetId, string imageUrl, List<string> tags = null, string meta = null)
                : this(imageSetId, tags, meta)
        {
            this.ImageUrl = imageUrl;
        }
    }
}