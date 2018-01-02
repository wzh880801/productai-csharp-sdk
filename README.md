# ProductAI® SDK for .NET & .NET Core

[![Build status](https://ci.appveyor.com/api/projects/status/34b787k7hrbk59q6/branch/master?svg=true)](https://ci.appveyor.com/project/wzh880801/productai-csharp-sdk/branch/master)
[![NuGet](https://img.shields.io/nuget/v/MalongTech.ProductAI.API.svg)](https://www.nuget.org/packages/MalongTech.ProductAI.API/)
[![NuGet](https://img.shields.io/nuget/dt/MalongTech.ProductAI.API.svg)](https://www.nuget.org/packages/MalongTech.ProductAI.API/)

## ProductAI: 
<br>For more details about ProductAI, view 
- [ProductAI Global offcial site](http://www.productai.com) 
- [ProductAI China offcial site](http://www.productai.cn) 
- [ProductAI Documentation](https://api-doc.productai.cn/doc/pai.html)

# Usage（用法）:
## Install
Nuget Keywords: *ProductAI*, *Malong*

Nuget Command-Line:
```
Install-Package MalongTech.ProductAI.API
```

# Requirements & dependencies
## .NET45
 - .NET Framework 4.5+
 - Newtonsoft.Json
## NET CORE
- .NET Core or .NET Standard 1.0+
- Newtonsoft.Json

## Example code
[See Example Codes](https://github.com/MalongTech/productai-csharp-sdk/blob/master/source-latest/net45/MalongTech.ProductAI.Examples/Program.cs)

```C#
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
```

# Support async (支持异步)

```C#
var request = new DetectByImageFileRequest(DetectType.ThreeCAndElectronics)
{
    ImageFile = new System.IO.FileInfo(@".\Detect\iphone.jpg"),
    Language = LanguageType.Chinese
};
var response = await client.GetResponseAsync(request);
```

# Release Notes（更新日志）
## 2018-01-02
 - Batch Apis (数任务管理Api)
 [Batch Api Example](https://github.com/MalongTech/productai-csharp-sdk/tree/master/source-latest/net45/MalongTech.ProductAI.Examples/batch_tasks)

 - Color Apis （色彩标注服务Api）
 [Color Api Example](https://github.com/MalongTech/productai-csharp-sdk/tree/master/source-latest/net45/MalongTech.ProductAI.Examples/color)

 - Dressing Api Examples（时尚分析示例）
 [Dressing Api Examples](https://github.com/MalongTech/productai-csharp-sdk/tree/master/source-latest/net45/MalongTech.ProductAI.Examples/dressing)

## 2017-12-21
 - Dataset Management Apis (数据集管理Api)
 - Search Service Management Apis （搜索服务管理Api）

 ```C#
 using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// Dataset management apis
    /// 数据集操作: 检索、新增、更新、删除
    /// </summary>
    class DataSetManagementExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 数据集操作  <==");

            Console.WriteLine("==>  Demo - 新增  <==");
            Add(client);

            Console.WriteLine("==>  Demo - 检索  <==");
            Get(client);

            Console.WriteLine("==>  Demo - 更新  <==");
            Update(client);

            Console.WriteLine("==>  Demo - 删除  <==");
            Delete(client);
        }

        private string _dataSetId = "";

        // Add a new dataset 
        // 新增一个数据集
        private void Add(IWebClient client)
        {
            var request = new CreateDataSetRequest
            {
                Name = "MyExampleDs",
                Description = "我的数据集描述-测试"
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("DataSet Id: {0}", response.DataSetId);
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                Console.WriteLine("==========================Result==========================");

                _dataSetId = response.DataSetId;
            }
            catch (ServerException ex)
            {
                Console.WriteLine("ServerException happened: \r\n\tErrorCode: {0}\r\n\tErrorMessage: {1}",
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (ClientException ex)
            {
                Console.WriteLine("ClientException happened: \r\n\tRequestId: {0}\r\n\tErrorCode: {1}\r\n\tErrorMessage: {2}",
                    ex.RequestId,
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown Exception happened: {0}\r\n{1}", ex.Message, ex.StackTrace);
            }
        }

        // get the detail information of a dataset
        // 获取一个数据集的详细信息
        private void Get(IWebClient client)
        {
            var request = new GetDataSetInfoRequest
            {
                DataSetId = _dataSetId
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                Console.WriteLine("==========================Result==========================");
            }
            catch (ServerException ex)
            {
                Console.WriteLine("ServerException happened: \r\n\tErrorCode: {0}\r\n\tErrorMessage: {1}",
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (ClientException ex)
            {
                Console.WriteLine("ClientException happened: \r\n\tRequestId: {0}\r\n\tErrorCode: {1}\r\n\tErrorMessage: {2}",
                    ex.RequestId,
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown Exception happened: {0}\r\n{1}", ex.Message, ex.StackTrace);
            }
        }

        // update a existing dataset
        // 更新dataset的信息（名称和描述）
        private void Update(IWebClient client)
        {
            var request = new UpdateDataSetRequest
            {
                Name = "MyDs-Updated",
                Description = "我的数据集描述-测试-Updated",
                DataSetId = _dataSetId
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("LastModifiedTime: {0}", response.LastModifiedTime);
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                Console.WriteLine("==========================Result==========================");
            }
            catch (ServerException ex)
            {
                Console.WriteLine("ServerException happened: \r\n\tErrorCode: {0}\r\n\tErrorMessage: {1}",
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (ClientException ex)
            {
                Console.WriteLine("ClientException happened: \r\n\tRequestId: {0}\r\n\tErrorCode: {1}\r\n\tErrorMessage: {2}",
                    ex.RequestId,
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown Exception happened: {0}\r\n{1}", ex.Message, ex.StackTrace);
            }
        }

        // delete a dataset
        // 删除一个数据集
        private void Delete(IWebClient client)
        {
            var request = new DeleteDataSetRequest
            {
                DataSetId = _dataSetId
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                Console.WriteLine("==========================Result==========================");
            }
            catch (ServerException ex)
            {
                Console.WriteLine("ServerException happened: \r\n\tErrorCode: {0}\r\n\tErrorMessage: {1}",
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (ClientException ex)
            {
                Console.WriteLine("ClientException happened: \r\n\tRequestId: {0}\r\n\tErrorCode: {1}\r\n\tErrorMessage: {2}",
                    ex.RequestId,
                    ex.ErrorCode,
                    ex.ErrorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown Exception happened: {0}\r\n{1}", ex.Message, ex.StackTrace);
            }
        }
    }
}
 ```
