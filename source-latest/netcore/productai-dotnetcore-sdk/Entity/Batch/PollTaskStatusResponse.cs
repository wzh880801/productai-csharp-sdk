using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity.Batch
{
    public class PollTaskStatusResponse : Core.BaseResponse
    {
        [JsonProperty("data")]
        public TaskDetailInfo TaskInfo { get; set; }
    }

    public class TaskDetailInfo
    {
        [JsonProperty("csv")]
        public string CsvFileUrl { get; set; }

        [JsonProperty("download_urls")]
        public string[] DownloadedUrls { get; set; }

        [JsonProperty("received_time")]
        public string ReceivedTime { get; set; }

        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("state")]
        public string StateString { get; set; }

        private static Dictionary<int, string> _dics = typeof(Core.TaskStatus).ToDictionary();
        public Core.TaskStatus TaskStatus
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.StateString))
                    return Core.TaskStatus.UNKNOWN;

                return (Core.TaskStatus)_dics.FirstOrDefault(p => p.Value.Equals(this.StateString, StringComparison.CurrentCultureIgnoreCase)).Key;
            }
        }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("total")]
        public long TotalCount { get; set; }

        [JsonProperty("success")]
        public long SuccessCount { get; set; }

        [JsonProperty("estimated_processing_time")]
        public int EstimatedProcessingTime { get; set; }

        [JsonProperty("estimated_waiting_time")]
        public int EstimatedWaitingTime { get; set; }
    }
}
