using System;

namespace MalongTech.ProductAI.Core
{
    public enum LanguageType
    {
        /// <summary>
        /// return results in English
        /// </summary>
        [EnumDescription(Text = "en-US")]
        English,

        /// <summary>
        /// return results in Chinese
        /// </summary>
        [EnumDescription(Text = "zh-Hans-CN")]
        Chinese
    }
}