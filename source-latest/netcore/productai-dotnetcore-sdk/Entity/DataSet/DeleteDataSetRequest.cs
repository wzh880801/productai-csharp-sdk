using System;

namespace MalongTech.ProductAI.API.Entity
{
    public class DeleteDataSetRequest : Core.BaseRequest<DeleteDataSetResponse>
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

        public DeleteDataSetRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.DELETE;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSetId">数据集ID</param>
        public DeleteDataSetRequest(string dataSetId)
            : this()
        {
            this.DataSetId = dataSetId;
        }
    }
}
