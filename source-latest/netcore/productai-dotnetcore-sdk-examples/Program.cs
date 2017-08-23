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
            IExample search_by_file_example = new ImageSearchByFileExample();
            search_by_file_example.Run(client);

            IExample search_by_url_example = new ImageSearchByUrlExample();
            search_by_url_example.Run(client);

            //Smart filter
            IExample filter_by_file_example = new FilterByFileExample();
            filter_by_file_example.Run(client);

            IExample filter_by_url_example = new FilterByUrlExample();
            filter_by_url_example.Run(client);

            //Detect
            IExample detect_by_file_example = new DetectByFileExample();
            detect_by_file_example.Run(client);

            IExample detect_by_url_example = new DetectByUrlExample();
            detect_by_url_example.Run(client);

            //Classify
            IExample classify_by_file_example = new ClassifyByFileExample();
            classify_by_file_example.Run(client);

            IExample classify_by_url_example = new ClassifyByUrlExample();
            classify_by_url_example.Run(client);

            //Dataset
            IExample dataset_batch_add_example = new DataSetBatchAddFilesExample();
            dataset_batch_add_example.Run(client);

            IExample dataset_batch_delete_example = new DataSetBatchDeleteFilesExample();
            dataset_batch_delete_example.Run(client);

            IExample dataset_single_add_example = new DataSeSingleAddExample();
            dataset_single_add_example.Run(client);

            Console.WriteLine("\r\nDone");
            Console.ReadLine();
        }
    }
}