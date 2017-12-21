using System;
using Newtonsoft.Json;

namespace MalongTech.ProductAI.API.Entity
{
    public class DressingClassifyResult
    {
        [JsonProperty("box")]
        public decimal[] Box { get; set; }

        [JsonProperty("textures")]
        public string[] Textures { get; set; }

        [JsonProperty("textures-en")]
        public string[] TexturesEN { get; set; }

        [JsonProperty("colors")]
        public DressColor[] Colors { get; set; }

        [JsonProperty("item")]
        public string Item { get; set; }

        [JsonProperty("item-en")]
        public string ItemEN { get; set; }

        public class DressColor
        {
            [JsonProperty("basic-cn")]
            public string CnName { get; set; }

            [JsonProperty("rgb")]
            public byte[] RGB { get; set; }

            [JsonProperty("w3c-cn")]
            public string W3cCN { get; set; }

            [JsonProperty("w3c-en")]
            public string W3cEn { get; set; }

            [JsonProperty("basic-en")]
            public string EnName { get; set; }

            [JsonProperty("ncs")]
            public string Ncs { get; set; }

            [JsonProperty("percent")]
            public double Percent { get; set; }
        }
    }
}