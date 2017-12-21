using System;
using System.Collections.Generic;
using System.Reflection;

namespace MalongTech.ProductAI.Core
{
    public abstract class ManagementAPIBaseRequest<T> : BaseRequest<T>
        where T : BaseResponse
    {
        public ManagementAPIBaseRequest() 
            : base()
        {
            this.ContentType = ContentType.Json;
        }

        public override string QueryString
        {
            get
            {
                var dics = new Dictionary<string, object>();
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
                                dics.Add(_ca.Name, value);
                            }
                        }
                        else if (p.PropertyType == typeof(int?))
                        {
                            var v = value as int?;
                            if (v != null)
                                dics.Add(_ca.Name, v);
                        }
                        else if (p.PropertyType == typeof(double?))
                        {
                            var v = value as double?;
                            if (v != null)
                                dics.Add(_ca.Name, v);
                        }
                        else
                        {
                            dics.Add(_ca.Name, value);
                        }
                    }
                }

                // 可选参数
                if (this.Options != null && this.Options.Count > 0)
                {
                    foreach (var para in this.Options)
                    {
                        dics.Add(para.Key, WebQueryHelper.UrlEncode(para.Value));
                    }
                }

                return Newtonsoft.Json.JsonConvert.SerializeObject(dics);
            }
        }
    }
}
