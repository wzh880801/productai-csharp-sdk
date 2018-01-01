using System;

namespace MalongTech.ProductAI.Core
{
    public enum SubType
    {
        [EnumDescription("everything")]
        EveryThing,

        [EnumDescription("person_outfit")]
        PersonOutfit,

        [EnumDescription("foreground")]
        Foreground
    }

    public enum Granularity
    {
        /// <summary>
        /// 只返回整个图片最主要的两种颜色
        /// </summary>
        [EnumDescription("major")]
        Major,

        /// <summary>
        /// 返回图片内更多的颜色
        /// </summary>
        [EnumDescription("detailed")]
        Detailed,

        /// <summary>
        /// 只返回一个图片主颜色
        /// </summary>
        [EnumDescription("dominant")]
        Dominant
    }

    public enum ColorReturnType
    {
        [EnumDescription("basic")]
        Basic,

        /// <summary>
        /// W3C的CSS工作组发布CSS颜色模块
        /// </summary>
        [EnumDescription("w3c")]
        W3C,

        /// <summary>
        /// NCS色卡是来自瑞典的色彩设计工具，它以眼睛看颜色的方式来描述颜色。表面颜色定义在NCS色卡中，同时给出一个色彩编号。
        /// </summary>
        [EnumDescription("ncs")]
        NCS,

        /// <summary>
        /// CNCS是由中国纺织信息中心联合国际国内色彩专家和机构，经多年精心调研而开发的色彩体系，力求为服装设计师和相关机构提供当前最时尚的色彩信息和色彩管理解决方案。
        /// </summary>
        [EnumDescription("cncs")]
        CNCS
    }
}
