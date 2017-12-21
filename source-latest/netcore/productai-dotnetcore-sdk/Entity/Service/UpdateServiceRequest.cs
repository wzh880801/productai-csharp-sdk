using System;

namespace MalongTech.ProductAI.API.Entity
{
    public class UpdateServiceRequest : Core.ManagementAPIBaseRequest<UpdateServiceResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/customer_services/_0000172/{1}", this.Host, this.ServiceId);
            }
        }

        /// <summary>
        /// 服务ID
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// 服务名称
        /// 32个字符，超过部分会被截断
        /// </summary>
        [Core.ParaSign("name", true)]
        public string Name { get; set; }

        public UpdateServiceRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.PUT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceId">数据集ID</param>
        /// <param name="name">服务名称</param>
        public UpdateServiceRequest(string serviceId, string name)
            : this()
        {
            this.ServiceId = serviceId;
            this.Name = name;
        }
    }
}
