using System;

namespace MalongTech.ProductAI.API.Entity
{
    public class DeleteServiceRequest : Core.BaseRequest<DeleteServiceResponse>
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

        public DeleteServiceRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.DELETE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceId">服务ID</param>
        public DeleteServiceRequest(string serviceId)
            : this()
        {
            this.ServiceId = serviceId;
        }
    }
}
