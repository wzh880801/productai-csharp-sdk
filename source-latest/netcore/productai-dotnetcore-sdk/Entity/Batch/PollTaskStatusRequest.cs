using System;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class PollTaskStatusRequest : Core.BaseRequest<PollTaskStatusResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/batch/_1000001/task/info/{1}", this.Host, this.TaskId);
            }
        }

        public string TaskId { get; set; }

        public PollTaskStatusRequest()
            : base()
        {
            this.RequestMethod = Core.HttpMethod.GET;
        }

        public PollTaskStatusRequest(string taskId) 
            : this()
        {
            this.TaskId = taskId;
        }
    }
}
