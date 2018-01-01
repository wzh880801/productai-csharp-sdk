using System;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    /// <summary>
    /// 只有任务在队列中（状态字段state为PENDING）时，任务可以被取消．一旦任务开始运行，则不可被取消．
    /// </summary>
    public class CancelTaskRequest : Core.BaseRequest<CancelTaskResponse>
    {
        public override string ApiUrl
        {
            get
            {
                return string.Format("https://{0}/batch/_1000001/task/revoke/{1}", this.Host, this.TaskId);
            }
        }

        public string TaskId { get; set; }

        public CancelTaskRequest()
            : base()
        {

        }

        public CancelTaskRequest(string taskId)
            : this()
        {
            this.TaskId = taskId;
        }
    }
}
