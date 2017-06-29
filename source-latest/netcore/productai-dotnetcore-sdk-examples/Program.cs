using System;
using MalongTech.ProductAI.Core;

namespace MalongTech.ProductAI.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            IProfile profile = new DefaultProfile
            {
                Version = "1",
                AccessKeyId = AppConfig.ACCESS_KEY_ID,
                SecretKey = AppConfig.SECRET_KEY,
                GlobalLanguage = LanguageType.Chinese
            };
            var client = new DefaultProductAIClient(profile);

            //Image search
            IExample search_example = new ImageSearchExample();
            search_example.Run(client);

            //Smart filter
            IExample filter_example = new SmartFilterExample();
            filter_example.Run(client);

            //Detect
            IExample detect_example = new DetectExample();
            detect_example.Run(client);

            //Classify
            IExample classify_example = new ClassifyPlaceExample();
            classify_example.Run(client);

            Console.WriteLine("\r\nDone");
            Console.ReadLine();
        }
    }
}