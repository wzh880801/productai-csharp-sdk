﻿using System;
using System.Collections.Generic;
using System.Reflection;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API
{
    /// <summary>
    /// The base request class using the image url to call the api.
    /// You can't directly initilaze this class, instead, you should the subclass of it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CallApiByImageUrlBaseRequest<T> : BaseRequest<T>
        where T : BaseResponse
    {
        private static Dictionary<int, string> _serviceTypeDicts = typeof(ServiceType).ToDictionary();

        private string _serviceType = "";
        private string _serviceId = "";

        public string ServiceTye
        {
            get
            {
                return _serviceType;
            }
            set
            {
                _serviceType = value;
            }
        }

        public string ServiceId
        {
            get
            {
                return _serviceId;
            }
            set
            {
                _serviceId = value;
            }
        }

        public ServiceType ServiceTypeValue
        {
            set
            {
                this._serviceType = _serviceTypeDicts[(int)value];
            }
        }

        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/{1}/{2}/", this.Host, this._serviceType, this._serviceId);
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
        //                else if (p.PropertyType == typeof(int?))
        //                {
        //                    var v = value as int?;
        //                    if (v != null)
        //                        list.Add(string.Format("{0}={1}", _ca.Name, v));
        //                }
        //                else if (p.PropertyType == typeof(double?))
        //                {
        //                    var v = value as double?;
        //                    if (v != null)
        //                        list.Add(string.Format("{0}={1}", _ca.Name, v));
        //                }
        //            }
        //        }

        //        if (this.Options != null && this.Options.Count > 0)
        //        {
        //            foreach(var para in this.Options)
        //            {
        //                list.Add(string.Format("{0}={1}", para.Key, WebQueryHelper.UrlEncode(para.Value)));
        //            }
        //        }

        //        return string.Join("&", list);
        //        //return string.Format("url={0}&loc={1}", System.Web.HttpUtility.UrlEncode(this.Url), this.Loc);
        //    }
        //}

        public CallApiByImageUrlBaseRequest()
        {

        }

        public CallApiByImageUrlBaseRequest(string serviceType, string serviceId)
            : base()
        {
            if (string.IsNullOrWhiteSpace(serviceType))
                throw new ArgumentNullException(nameof(serviceType));
            if(string.IsNullOrWhiteSpace(serviceId))
                throw new ArgumentNullException(nameof(serviceId));

            this._serviceType = serviceType;
            this._serviceId = serviceId;
        }

        [ParaSign("url", true)]
        public string Url { get; set; }

        [ParaSign("loc")]
        public string Loc { get; set; }

        public CallApiByImageUrlBaseRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
            : this(serviceType, serviceId)
        {
            this.Loc = loc;
        }

        public CallApiByImageUrlBaseRequest(string serviceType, string serviceId, string url, string loc = "0-0-1-1")
            : this(serviceType, serviceId, loc)
        {
            this.Url = url;
        }
    }
}