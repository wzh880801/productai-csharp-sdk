using System;

namespace MalongTech.ProductAI.Core
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ServiceDescriptionAttribute : Attribute
    {
        public string Name { get; set; }
        public string ServiceType { get; set; }
        public string ServiceId { get; set; }

        public ServiceDescriptionAttribute()
            : base()
        {

        }

        public ServiceDescriptionAttribute(string name, string serviceType, string serviceId)
            : this()
        {
            this.Name = name;
            this.ServiceType = serviceType;
            this.ServiceId = serviceId;
        }
    }
}