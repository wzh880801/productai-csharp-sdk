using System;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class GetSupportServicesRequest : Core.BaseRequest<GetSupportServicesResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/batch/_1000001/services", this.Host);
            }
        }

        public GetSupportServicesRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.GET;
        }
    }
}
