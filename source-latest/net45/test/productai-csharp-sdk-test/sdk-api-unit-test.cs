using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Test
{
    [TestClass]
    public class SDKApiTest
    {
        IWebClient client = null;

        [TestInitialize]
        public void Init()
        {
            IProfile profile = new DefaultProfile
            {
                AccessKeyId = "123",
                SecretKey = "123",
                GlobalLanguage = LanguageType.Chinese,
                Version = "1"
            };
            client = new DefaultProductAIClient(profile);
        }

        [TestMethod]
        public void ClassifyTest()
        {
            var request = new ClassifyByImageUrlRequest("classify", "_0000072");
            try
            {
                var response = client.GetResponse(request);
            }
            catch (ClientException ex)
            {
                Assert.AreEqual("1002", ex.ErrorCode);
            }
        }
    }
}