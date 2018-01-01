using System;
using System.Linq;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class CreateTaskByFileResponse : Core.BaseResponse
    {
        [JsonProperty("data")]
        public TaskInfo TaskInfo { get; set; }
    }

    public class TaskInfo
    {
        /// <summary>
        /// 预计处理时间
        /// </summary>
        [JsonProperty("estimated_processing_time")]
        public int EstimatedProcessingTime { get; set; }

        /// <summary>
        /// 预计等待时间
        /// </summary>
        [JsonProperty("estimated_waiting_time")]
        public int EstimatedWaitingTime { get; set; }

        /// <summary>
        /// 当前任务状态(String)
        /// 
        ///         RECEIVED    任务被接受
        ///         PENDING     任务等待中
        ///         STARTED     任务启动
        ///         SUCCESS     任务执行成功
        ///         REVOKED     任务被取消
        ///         FAILUR      任务执行失败
        ///         
        /// </summary>
        [JsonProperty("state")]
        public string StateString { get; set; }

        private static Dictionary<int, string> _dics = typeof(Core.TaskStatus).ToDictionary();
        /// <summary>
        /// 当前任务状态
        /// </summary>
        public Core.TaskStatus Status
        {
            get
            {
                var status = Core.TaskStatus.FAILURE;
                if (string.IsNullOrWhiteSpace(this.StateString))
                    return status;
                try
                {
                    return (Core.TaskStatus)_dics.FirstOrDefault(p => p.Value.Equals(this.StateString, StringComparison.CurrentCultureIgnoreCase)).Key;
                }
                catch
                {

                }

                return status;
            }
        }

        /// <summary>
        /// 任务唯一ID，后续所有操作都基于该ID进行
        /// </summary>
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// 任务中包含的待处理图片数量
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// 详细错误代码
        /// </summary>
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("message")]
        public string ErrorMessage { get; set; }

        //urls_duplicated 数组  返回所有重复的数据
        //urls_verify_failed  数组 不合法的url列表

        /// <summary>
        /// key is URL.
        /// value is int[]
        /// </summary>
        [JsonProperty("urls_duplicated")]
        public Dictionary<string, int[]> UrlsDuplicated { get; set; }

        /// <summary>
        /// key is index or row number.
        /// value is raw url string
        /// </summary>
        [JsonProperty("urls_verify_failed")]
        public Dictionary<int, string> UrlsVerifyFailed { get; set; }
    }
}
