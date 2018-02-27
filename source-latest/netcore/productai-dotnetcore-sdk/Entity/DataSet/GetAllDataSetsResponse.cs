using System;
using MalongTech.ProductAI.Core;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.API.Entity
{
    public class GetAllDataSetsResponse : BaseResponse
    {
        [JsonProperty("results")]
        public Dataset[] Datasets { get; set; }
    }

    public class Dataset
    {
        /// <summary>
        /// 目前数据集状态．没有任何图片被下载完毕，是not-downloaded．如果有部分图片被下载完毕，部分没有被下载完毕，是downloading．如果所有图片都被下载完毕，或者下载失败，是downloaded．
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 数据集中下载完毕的图片数
        /// </summary>
        [JsonProperty("n_downloaded")]
        public int DownloaedCount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// 最后修改UTC时间，精确到秒
        /// </summary>
        [JsonProperty("modified_at")]
        public string LastModifiedTime { get; set; }

        /// <summary>
        /// 字符串（年-月-日T小时:分钟:秒Z）
        /// String(Year-Month-DayTHour:Minute:SecondZ)
        /// UTC
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        /// <summary>
        /// 数据集中所有的图片数
        /// </summary>
        [JsonProperty("n_items")]
        public int ItemsSearchedCount { get; set; }

        /// <summary>
        /// 数据集唯一ID，后续操作都需要基于此ID进行
        /// </summary>
        [JsonProperty("id")]
        public string DataSetId { get; set; }

        /// <summary>
        /// 数据集名称
        /// </summary>
        [JsonProperty("name")]
        public string DataSetName { get; set; }

        /// <summary>
        /// 数据集中下载失败的图片数
        /// </summary>
        [JsonProperty("n_failed")]
        public int FailedCount { get; set; }
    }
}