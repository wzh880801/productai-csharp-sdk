using System;

namespace MalongTech.ProductAI.Core
{
    /// <summary>
    /// This is your account profile.
    /// You could get your accessKeyId & accessKeySecret at https://console.productai.cn/main#/21/service_category_id=1
    /// </summary>
    public interface IProfile
    {
        /// <summary>
        /// your access_key_id
        /// </summary>
        string AccessKeyId { get; set; }

        /// <summary>
        /// your secret_key
        /// </summary>
        string SecretKey { get; set; }

        /// <summary>
        /// API Version. Default is "1"
        /// </summary>
        string Version { get; set; }

        /// <summary>
        /// The global config of your language.
        /// This will override the Language Value of the request if its value is not null.
        /// </summary>
        LanguageType? GlobalLanguage { get; set; }
    }
}