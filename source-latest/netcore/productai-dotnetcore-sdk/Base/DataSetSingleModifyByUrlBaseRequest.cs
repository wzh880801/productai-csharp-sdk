﻿using System;
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

        //public override string QueryString
        //{
        //    get
        //    {
        //        var list = new List<string>();
        //        var ps = this.GetType().GetProperties();
        //        foreach (var p in ps)
        //        {
        //            var ca = p.GetCustomAttribute(typeof(ParaSignAttribute));
        //            if (ca != null)
        //            {
        //                var _ca = ca as ParaSignAttribute;
        //                var value = p.GetValue(this);
        //                if (p.PropertyType == typeof(System.String))
        //                {
        //                    if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
        //                    {
        //                        list.Add(string.Format("{0}={1}", _ca.Name, _ca.IsNeedUrlEncode ? WebQueryHelper.UrlEncode(value.ToString()) : value));
        //                    }
        //                }
        //            }
        //        }
        //        return string.Join("&", list);
        //    }
        //}

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