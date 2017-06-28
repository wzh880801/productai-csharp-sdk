using System;

namespace MalongTech.ProductAI.Core
{
    /// <summary>
    /// Determines that whether the property should be included when calculating the url signature.
    /// </summary>
    public class ParaSignAttribute : System.Attribute
    {
        /// <summary>
        /// the name used when calculating the url signature
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// whether the property should be UrlEncoded.
        /// </summary>
        public bool IsNeedUrlEncode { get; set; }

        public ParaSignAttribute()
        {

        }

        public ParaSignAttribute(string name, bool isNeedUrlEncode = false)
        {
            this.Name = name;
            this.IsNeedUrlEncode = isNeedUrlEncode;
        }
    }
}