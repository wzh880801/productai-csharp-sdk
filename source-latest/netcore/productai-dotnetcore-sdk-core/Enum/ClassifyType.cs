using System;

namespace MalongTech.ProductAI.Core
{
    public enum ClassifyType
    {
        /// <summary>
        /// 场景分析与标注
        /// classify_place_cls
        /// </summary>
        [ServiceDescription(Name = "场景分析与标注", ServiceType = "classify", ServiceId = "_0000039")]
        Place,

        /// <summary>
        /// 色情分析与标注
        /// classify_porn
        /// </summary>
        [ServiceDescription(Name = "色情分析与标注", ServiceType = "classify", ServiceId = "_0000024")]
        Pornography,

        /// <summary>
        /// 通用图片内容分析与标注
        /// classify_general
        /// </summary>
        [ServiceDescription(Name = "通用图片内容分析与标注", ServiceType = "classify", ServiceId = "_0000044")]
        General
    }
}