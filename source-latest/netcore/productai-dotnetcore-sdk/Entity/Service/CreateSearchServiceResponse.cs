using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.API.Entity
{
    public class CreateSearchServiceResponse : Core.BaseResponse
    {
        /// <summary>
        /// 创建UTC时间，精确到秒
        /// 字符串（年-月-日T小时:分钟:秒Z）
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        /// <summary>
        /// 搜索服务唯一ID，后续操作都需要基于此ID进行
        /// </summary>
        [JsonProperty("id")]
        public string ServiceId { get; set; }

        /// <summary>
        /// 搜索服务基于的数据集ID
        /// </summary>
        [JsonProperty("image_set_id")]
        public string ImageSetId { get; set; }

        /// <summary>
        /// 索引完成率 = 索引的图片数 / 下完成的图片数
        /// </summary>
        [JsonProperty("indexed_ratio")]
        public float IndexedRatio { get; set; }

        /// <summary>
        /// 搜索服务最后一次索引部署时间
        /// </summary>
        [JsonProperty("last_indexed_time")]
        public string LastIndexedTime { get; set; }

        /// <summary>
        /// 最后修改UTC时间，精确到秒
        /// </summary>
        [JsonProperty("last_updated_at")]
        public string last_updated_at { get; set; }

        /// <summary>
        /// 当前搜索服务线上索引量
        /// </summary>
        [JsonProperty("n_indexed")]
        public long IndexedCount { get; set; }

        /// <summary>
        /// 搜索服务名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("scenario")]
        public string Scenario { get; set; }

        /// <summary>
        /// 目前搜索服务状态，只有running
        /// </summary>
        [JsonProperty("status")]
        public string StatusString { get; set; }

        private static Dictionary<int, string> _dics = typeof(Core.SearchScenario).ToDictionary();

        /// <summary>
        /// 目前搜索服务状态，只有running
        /// </summary>
        public Core.ServiceStatus Status
        {
            get
            {
                var status = Core.ServiceStatus.UnKnown;
                try
                {
                    status = (Core.ServiceStatus)_dics.FirstOrDefault(p => p.Value == this.StatusString).Key;
                }
                catch
                {

                }

                return status;
            }
        }

        [JsonProperty("status_duration")]
        public int StatusDuration { get; set; }
    }
}