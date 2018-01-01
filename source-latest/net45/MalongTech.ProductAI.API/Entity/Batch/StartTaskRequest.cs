using System;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class StartTaskRequest : Core.BaseRequest<StartTaskResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/batch/_1000001/task/apply", this.Host);
            }
        }

        [Core.ParaSign("task_id")]
        public string TaskId { get; set; }

        public StartTaskRequest()
            : base()
        {

        }

        public StartTaskRequest(string taskId) 
            : this()
        {
            this.TaskId = taskId;
        }
    }
}
