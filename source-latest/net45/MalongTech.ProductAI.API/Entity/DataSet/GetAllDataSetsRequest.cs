using System;

namespace MalongTech.ProductAI.API.Entity
{
    public class GetAllDataSetsRequest : Core.BaseRequest<GetAllDataSetsResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/image_sets/_0000014", this.Host);
            }
        }

        public GetAllDataSetsRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.GET;
        }
    }
}
