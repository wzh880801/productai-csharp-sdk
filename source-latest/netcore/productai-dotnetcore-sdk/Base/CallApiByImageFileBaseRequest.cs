using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API
{
    /// <summary>
    /// The base request class using the local image file to call the api.
    /// You can't directly initilaze this class, instead, you should the subclass of it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CallApiByImageFileBaseRequest<T> : BaseRequest<T>
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

        public override string QueryString
        {
            get
            {
                return "";
            }
        }

        private string _boundary = FileHelper.GetBoundary();

        public override byte[] QueryBytes
        {
            get
            {
                var options = new Dictionary<string, string>();
                var ps = this.GetType().GetProperties();
                foreach (var p in ps)
                {
                    var ca = p.GetCustomAttribute(typeof(ParaSignAttribute));
                    if (ca != null)
                    {
                        var _ca = ca as ParaSignAttribute;
                        var value = p.GetValue(this);
                        if (p.PropertyType == typeof(System.String))
                        {
                            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                            {
                                options.Add(_ca.Name, value.ToString());
                            }
                        }
                        else if (p.PropertyType == typeof(int?))
                        {
                            var v = value as int?;
                            if (v != null)
                                options.Add(_ca.Name, string.Format("{0}", v));
                        }
                        else if (p.PropertyType == typeof(double?))
                        {
                            var v = value as double?;
                            if (v != null)
                                options.Add(_ca.Name, string.Format("{0}", v));
                        }
                    }
                }

                if (this.Options != null && this.Options.Count > 0)
                {
                    foreach (var para in this.Options)
                    {
                        options.Add(para.Key, para.Value);
                    }
                }

                return FileHelper.GetMultipartBytes(this.ImageFile, _boundary, options, "search");
            }
        }

        public override string ContentTypeHeader
        {
            get
            {
                return FileHelper.GetContentType(_boundary);
            }
        }

        [ParaSign("loc")]
        public string Loc { get; set; }

        /// <summary>
        /// The image file
        /// </summary>
        public FileInfo ImageFile { get; set; }

        public CallApiByImageFileBaseRequest()
        {
            this._boundary = FileHelper.GetBoundary();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType">the service type</param>
        /// <param name="serviceId">the service id</param>
        public CallApiByImageFileBaseRequest(string serviceType, string serviceId)
        : this()
        {
            if (string.IsNullOrWhiteSpace(serviceType))
                throw new ArgumentNullException(nameof(serviceType));
            if (string.IsNullOrWhiteSpace(serviceId))
                throw new ArgumentNullException(nameof(serviceId));

            this._serviceType = serviceType;
            this._serviceId = serviceId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType">the service type</param>
        /// <param name="serviceId">the service id</param>
        /// <param name="loc">default is "0-0-1-1"</param>
        public CallApiByImageFileBaseRequest(string serviceType, string serviceId, string loc = "0-0-1-1")
                : this(serviceType, serviceId)
        {
            this.Loc = loc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType">the service type</param>
        /// <param name="serviceId">the service id</param>
        /// <param name="imageFile">the local image file</param>
        /// <param name="loc">default is "0-0-1-1"</param>
        public CallApiByImageFileBaseRequest(string serviceType, string serviceId, FileInfo imageFile, string loc = "0-0-1-1")
                : this(serviceType, serviceId, loc)
        {
            this.ImageFile = imageFile;
        }
    }
}