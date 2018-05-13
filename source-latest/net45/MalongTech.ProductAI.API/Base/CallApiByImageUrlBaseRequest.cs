using System;
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

        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/{1}/{2}/", this.Host, this._serviceType, this._serviceId);
            }
        }

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