using System;

namespace MalongTech.ProductAI.Core
{
    public enum TaskStatus
    {
        /// <summary>
        /// 任务被接受
        /// </summary>
        [EnumDescription("RECEIVED")]
        RECEIVED,

        /// <summary>
        /// 任务等待中
        /// </summary>
        [EnumDescription("PENDING")]
        PENDING,

        /// <summary>
        /// 任务启动
        /// </summary>
        [EnumDescription("STARTED")]
        STARTED,

        /// <summary>
        /// 任务执行成功
        /// </summary>
        [EnumDescription("SUCCESS")]
        SUCCESS,

        /// <summary>
        /// 任务被取消
        /// </summary>
        [EnumDescription("REVOKED")]
        REVOKED,

        /// <summary>
        /// 任务执行失败
        /// </summary>
        [EnumDescription("FAILURE")]
        FAILURE,

        [EnumDescription("UNKNOWN")]
        UNKNOWN
    }
}
