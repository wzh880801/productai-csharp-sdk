using System;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            IProfile profile = new DefaultProfile
            {
                Version = "1",
                AccessKeyId = "XXXXXXXXXXXXXXXXXXXXXXXXX",
                SecretKey = "XXXXXXXXXXXXXXXXXXXXXXX",
                GlobalLanguage = LanguageType.Chinese
            };
            var client = new DefaultProductAIClient(profile);

            IExample example = new ImageSearchExample();
            example.Run(client);

            Console.WriteLine("\r\nDone");
            Console.ReadLine();
        }
    }
}