using System;

namespace MalongTech.ProductAI.Core
{
    /// <summary>
    /// The default profile
    /// </summary>
    public class DefaultProfile : IProfile
    {
        public string AccessKeyId { get; set; }
        public string SecretKey { get; set; }
        public string Version { get; set; }
        public LanguageType? GlobalLanguage { get; set; }

        public DefaultProfile()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessKeyId">Your access_key_id</param>
        /// <param name="secretKey">Your secret_key</param>
        /// <param name="version">Default is "1"</param>
        public DefaultProfile(string accessKeyId, string secretKey, string version = "1")
        {
            this.AccessKeyId = accessKeyId;
            this.SecretKey = secretKey;
            this.Version = version;
        }
    }
}