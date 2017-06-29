using System;

namespace MalongTech.ProductAI.Core
{
    public enum ClassifyType
    {
        /// <summary>
        /// 场景分析与标注
        /// classify_place_cls
        /// </summary>
        [ServiceDescription(Name = "场景分析与标注", ServiceType = "classify_place_cls", ServiceId = "_0000039")]
        Place,

        ///// <summary>
        ///// 时尚智能分析
        ///// classify_dressing
        ///// </summary>
        //[ServiceDescription(Name = "时尚智能分析", ServiceType = "classify_dressing", ServiceId = "_0000057")]
        //Dressing,

        /// <summary>
        /// 色情分析与标注
        /// classify_porn
        /// </summary>
        [ServiceDescription(Name = "色情分析与标注", ServiceType = "classify_porn", ServiceId = "_0000024")]
        Pornography,

        /// <summary>
        /// 通用图片内容分析与标注
        /// classify_general
        /// </summary>
        [ServiceDescription(Name = "通用图片内容分析与标注", ServiceType = "classify_general", ServiceId = "_0000044")]
        General
    }
}