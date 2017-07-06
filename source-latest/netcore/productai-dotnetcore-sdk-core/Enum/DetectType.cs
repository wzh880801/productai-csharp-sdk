using System;

namespace MalongTech.ProductAI.Core
{
    public enum DetectType
    {
        /// <summary>
        /// 3C电器检测与定位
        /// classify_place_cls
        /// </summary>
        [ServiceDescription(Name = "3C电器检测与定位", ServiceType = "detect", ServiceId = "_0000027")]
        ThreeCAndElectronics,

        /// <summary>
        /// 交通工具检测与定位
        /// </summary>
        [ServiceDescription(Name = "交通工具检测与定位", ServiceType = "detect", ServiceId = "_0000033")]
        Vehicle,

        /// <summary>
        /// 宠物检测与定位
        /// </summary>
        [ServiceDescription(Name = "宠物检测与定位", ServiceType = "detect", ServiceId = "_0000031")]
        Pet,

        /// <summary>
        /// 家具与家居用品检测与定位
        /// </summary>
        [ServiceDescription(Name = "家具与家居用品检测与定位", ServiceType = "detect", ServiceId = "_0000029")]
        Furniture,

        /// <summary>
        /// 常见商品检测与定位
        /// </summary>
        [ServiceDescription(Name = "常见商品检测与定位", ServiceType = "detect", ServiceId = "_0000030")]
        Ordinary,

        /// <summary>
        /// 服装检测与定位
        /// </summary>
        [ServiceDescription(Name = "服装检测与定位", ServiceType = "detect", ServiceId = "_0000025")]
        Cloth,

        /// <summary>
        /// 食品检测与定位
        /// </summary>
        [ServiceDescription(Name = "食品检测与定位", ServiceType = "detect", ServiceId = "_0000028")]
        Food
    }
}