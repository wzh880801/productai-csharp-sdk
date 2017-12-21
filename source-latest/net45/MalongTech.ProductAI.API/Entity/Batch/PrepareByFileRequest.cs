using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    // base_url:        /batch/_1000001
    // apply:           /batch/_1000001/task/apply      { "task_id": task_id }
    // get_services:    /batch/_1000001/services/
    // prepare          /batch/_1000001/task/prepare    { "service_id": service_id, "urls": file}

    // 先隐藏掉
    internal class PrepareByFileRequest : Core.BaseRequest<PrepareByFileResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/batch/_1000001/task/prepare", this.Host);
            }
        }

        [Core.ParaSign("service_id")]
        public string ServiceId { get; set; }

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

                return FileHelper.GetMultipartBytes(this.CsvFile, _boundary, options, "urls");
            }
        }

        public override string ContentTypeHeader
        {
            get
            {
                return FileHelper.GetContentType(_boundary);
            }
        }

        /// <summary>
        /// The image file
        /// </summary>
        public FileInfo CsvFile { get; set; }

        public PrepareByFileRequest()
            : base()
        {
            this._boundary = FileHelper.GetBoundary();
        }

        public PrepareByFileRequest(string serviceId, FileInfo csvFile)
            : this()
        {
            this.ServiceId = serviceId;
            this.CsvFile = csvFile;
        }
    }
}
