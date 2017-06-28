using System;
using System.Collections.Generic;
using System.Reflection;

namespace MalongTech.ProductAI.Core
{
    public static class EnumHelper
    {
        public static Dictionary<int, string> ToDictionary(this Type _enumType)
        {
            if (!_enumType.IsEnum)
                throw new InvalidCastException("Only support enum type!");
            var dic = new Dictionary<int, string>();

            var ps = _enumType.GetFields();
            foreach (var p in ps)
            {
                if (p.FieldType != _enumType)
                    continue;

                var at = p.GetCustomAttribute(typeof(EnumDescriptionAttribute));
                if (at != null)
                {
                    var a = at as EnumDescriptionAttribute;
                    dic.Add(Convert.ToInt32(p.GetValue(_enumType)), a.Text);
                }
                else
                {
                    dic.Add(Convert.ToInt32(p.GetValue(_enumType)), p.Name);
                }
            }

            return dic;
        }

        public static Dictionary<int, AIService> ToServiceDictionary(this Type _enumType)
        {
            if (!_enumType.IsEnum)
                throw new InvalidCastException("Only support enum type!");
            var dic = new Dictionary<int, AIService>();

            var ps = _enumType.GetFields();
            foreach (var p in ps)
            {
                if (p.FieldType != _enumType)
                    continue;

                var at = p.GetCustomAttribute(typeof(ServiceDescriptionAttribute));
                if (at != null)
                {
                    var a = at as ServiceDescriptionAttribute;
                    dic.Add(Convert.ToInt32(p.GetValue(_enumType)), new AIService
                    {
                        Name = a.Name,
                        ServiceType = a.ServiceType,
                        ServiceId = a.ServiceId
                    });
                }
                else
                    throw new Exception(string.Format("{0} has no ServiceDescriptionAttribute", p.Name));
            }

            return dic;
        }
    }
}