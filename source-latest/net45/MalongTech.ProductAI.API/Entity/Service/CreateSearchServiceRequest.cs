using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    public class CreateSearchServiceRequest : Core.ManagementAPIBaseRequest<CreateSearchServiceResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/image_sets/_0000014/{1}/services", this.Host, this.DataSetId);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DataSetId { get; set; }

        /// <summary>
        /// 服务名称
        /// 32个字符，超过部分会被截断
        /// </summary>
        [Core.ParaSign("name", true)]
        public string Name { get; set; }

        /// <summary>
        /// 场景类别
        /// </summary>
        public Core.SearchScenario Scenario { get; set; }

        private static Dictionary<int, string> _dics = typeof(Core.SearchScenario).ToDictionary();

        [Core.ParaSign("scenario")]
        public string ScenarioString
        {
            get
            {
                return _dics[(int)this.Scenario];
            }
        }

        public CreateSearchServiceRequest()
            : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageSetId">数据集ID</param>
        /// <param name="name">服务名称</param>
        /// <param name="scenario">场景类别</param>
        public CreateSearchServiceRequest(string imageSetId, string name, SearchScenario scenario)
            : this()
        {
            this.DataSetId = imageSetId;
            this.Name = name;
            this.Scenario = scenario;
        }
    }
}
