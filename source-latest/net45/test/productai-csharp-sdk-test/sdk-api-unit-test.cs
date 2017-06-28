using System;
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
            var request = new ClassifyByImageUrlRequest(ClassifyType.Pornography);
            try
            {
                var response = client.GetResponse(request);
            }
            catch (ClientException ex)
            {
                Assert.AreEqual("1002", ex.ErrorCode);
            }
        }

        [TestMethod]
        public void DetectTest()
        {
            client.Profile.AccessKeyId = "3c289113a9b86b63f46551c895c2a617";
            client.Profile.SecretKey = "xxxx";//replace this using the real key to pass the test

            var request = new DetectByImageUrlRequest(DetectType.Cloth)
            {
                Url = "http://productai.cn/img/f10.jpg"
            };
            var response = client.GetResponse(request);
            Assert.AreEqual(200, (int)response.StatusCode);
        }
    }
}