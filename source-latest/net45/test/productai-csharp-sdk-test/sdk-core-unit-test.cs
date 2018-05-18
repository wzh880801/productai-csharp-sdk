using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.Test
{
    [TestClass]
    public class SDKCoreUnitTest
    {
        [TestMethod]
        public void SignatureTest()
        {
            var secretKey = "1234567";
            var dicts = new Dictionary<string, string>();
            dicts.Add("loc", "0-0-1-1");
            dicts.Add("url", "http://productai.cn");
            var sign = SignnatureHelper.Signnature(secretKey, dicts);

            Assert.AreEqual("yXj0ZztzO02Ip0jBWel69YnsAjA=", sign);
        }

        [TestMethod]
        public void TagTest()
        {
            ISearchTag andTag = new AndTag();
            andTag.Add("上衣");
            andTag.Add("蓝色");
            ITag searchTag = new SearchTag
            {
                Tag = andTag
            };
            Assert.AreEqual("{\"and\":[\"上衣\",\"蓝色\"]}", searchTag.ToString());

            ISearchTag orTag = new OrTag();
            orTag.Add("圆领");
            orTag.Add("休闲");

            andTag.Add(orTag);
        }

        [TestMethod]
        public void TagTest1()
        {
            ISearchTag andTag = new AndTag();
            andTag.Add("上衣");

            ISearchTag orTag = new OrTag();
            orTag.Add("蓝色");
            orTag.Add("休闲");

            andTag.Add(orTag);
            ITag searchTag = new SearchTag
            {
                Tag = andTag
            };

            Assert.AreEqual("{\"and\":[\"上衣\",{\"or\":[\"蓝色\",\"休闲\"]}]}", searchTag.ToString());
        }
    }
}