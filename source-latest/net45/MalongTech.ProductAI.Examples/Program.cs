using System;
using System.Configuration;
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
                AccessKeyId = ConfigurationManager.AppSettings["AccessKeyId"],
                SecretKey = ConfigurationManager.AppSettings["SecretKey"],
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