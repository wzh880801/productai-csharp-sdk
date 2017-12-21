using System;

namespace MalongTech.ProductAI.API.Entity
{
    public class GetServiceInfoRequest : Core.BaseRequest<GetServiceInfoResponse>
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

        public GetServiceInfoRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.GET;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceId">服务ID</param>
        public GetServiceInfoRequest(string serviceId)
            : this()
        {
            this.ServiceId = serviceId;
        }
    }
}
