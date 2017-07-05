using System;

namespace MalongTech.ProductAI.Core
{
    public enum ServiceType
    {
        [EnumDescription("filter")]
        Filter,

        [EnumDescription("classify")]
        Classify,

        [EnumDescription("detect")]
        Detect,

        [EnumDescription("dressing")]
        Dressing,

        [EnumDescription("color")]
        Color,
    }
}