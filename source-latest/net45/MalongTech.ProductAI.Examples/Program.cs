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

            // Image search
            // 图片搜索调用示例
            IExample search_by_file_example = new ImageSearchByFileExample();
            search_by_file_example.Run(client);

            IExample search_by_url_example = new ImageSearchByUrlExample();
            search_by_url_example.Run(client);

            // Detect
            // 图像检测调用示例
            IExample detect_by_file_example = new DetectByFileExample();
            detect_by_file_example.Run(client);

            IExample detect_by_url_example = new DetectByUrlExample();
            detect_by_url_example.Run(client);

            // Classify
            // 图像分析调用示例
            IExample classify_by_file_example = new ClassifyByFileExample();
            classify_by_file_example.Run(client);

            IExample classify_by_url_example = new ClassifyByUrlExample();
            classify_by_url_example.Run(client);

            // Dataset
            // 数据集操作调用示例
            IExample dataset_batch_add_example = new DataSetBatchAddFilesExample();
            dataset_batch_add_example.Run(client);

            IExample dataset_batch_delete_example = new DataSetBatchDeleteFilesExample();
            dataset_batch_delete_example.Run(client);

            IExample dataset_single_add_example = new DataSetSingleAddExample();
            dataset_single_add_example.Run(client);

            // Dataset management API examples
            // 数据集管理（增删改查）API示例
            IExample dataset_management_example = new DataSetManagementExample();
            dataset_management_example.Run(client);

            // Search service management API examples
            // 搜索服务管理（增删改查）API示例
            IExample service_management_example = new ServiceManagementExample
            {
                DataSetId = "mhxy687b", //your dataset_id 您的数据集ID
            };
            service_management_example.Run(client);

            ////Smart filter
            //IExample filter_by_file_example = new FilterByFileExample();
            //filter_by_file_example.Run(client);

            //IExample filter_by_url_example = new FilterByUrlExample();
            //filter_by_url_example.Run(client);

            // Color API examples
            // 色彩标注服务
            IExample color_by_file_example = new ColorAnalysisByFileExample();
            color_by_file_example.Run(client);

            IExample color_by_url_example = new ColorAnalysisByUrlExample();
            color_by_url_example.Run(client);

            // Batch API examples
            // 批处理API示例
            IExample batch_example = new TasksExample();
            batch_example.Run(client);

            Console.WriteLine("\r\nDone");
            Console.ReadLine();
        }
    }
}