using System;

namespace MalongTech.ProductAI.API.Entity
{
    public class GetDataSetInfoRequest : Core.BaseRequest<GetDataSetInfoResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/image_sets/_0000014/{1}", this.Host, this.DataSetId);
            }
        }

        /// <summary>
        /// 数据集ID
        /// </summary>
        public string DataSetId { get; set; }

        public GetDataSetInfoRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.GET;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSetId">数据集ID</param>
        public GetDataSetInfoRequest(string dataSetId)
            : this()
        {
            this.DataSetId = dataSetId;
        }
    }
}
