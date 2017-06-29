using System;

namespace MalongTech.ProductAI.Core
{
    /// <summary>
    /// Content-Type header
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        /// application/x-www-form-urlencoded
        /// </summary>
        [EnumDescription(Text = "application/x-www-form-urlencoded; charset=UTF-8")]
        Default,

        /// <summary>
        /// application/json
        /// </summary>
        [EnumDescription(Text = "application/json; charset=UTF-8")]
        Json,

        /// <summary>
        /// multipart/form-data
        /// </summary>
        [EnumDescription(Text = "multipart/form-data;")]
        FormData
    }
}