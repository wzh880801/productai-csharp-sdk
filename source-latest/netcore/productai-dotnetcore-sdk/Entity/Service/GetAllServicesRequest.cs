using System;

namespace MalongTech.ProductAI.API.Entity
{
    public class GetAllServicesRequest : Core.BaseRequest<GetAllServicesResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/customer_services/_0000172", this.Host);
            }
        }

        public GetAllServicesRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.GET;
        }
    }
}
