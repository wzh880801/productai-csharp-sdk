using System;

namespace MalongTech.ProductAI.API.Entity
{
    public class CreateDataSetRequest : Core.ManagementAPIBaseRequest<CreateDataSetResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/image_sets/_0000014", this.Host);
            }
        }

        /// <summary>
        /// 数据集名称
        /// 最多16个unicode字符，超长的部分会被自动截断
        /// </summary>
        [Core.ParaSign("name", true)]
        public string Name { get; set; }

        /// <summary>
        /// 数据集的描述信息
        /// 最多128个unicode字符，超长的部分会被自动截断
        /// </summary>
        [Core.ParaSign("description", true)]
        public string Description { get; set; }

        public CreateDataSetRequest()
            : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">数据集名称</param>
        /// <param name="description">数据集的描述信息</param>
        public CreateDataSetRequest(string name, string description)
            : this()
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
