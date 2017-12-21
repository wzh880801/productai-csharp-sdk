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
## Example code
```C#
using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    class Useage
    {
        void FullFlowExample()
        {
            // step 1 - setup your account profile
            // get your accessKeyId & secretKey at https://console.productai.cn/main#/21/service_category_id=1
            IProfile profile = new DefaultProfile
            {
                Version = "1",
                AccessKeyId = "XXXXXXXXXXXXXXXXXXXXX",
                SecretKey = "XXXXXXXXXXXXXXXXXXXXX",

                // set this property = null if you want to control the language type of each request
                GlobalLanguage = LanguageType.Chinese
            };

            // step 2 - initialize your ProductAI client
            var client = new DefaultProductAIClient(profile);

            // step 3 - build your request
            // take image search as example
            var request = new ImageSearchByImageUrlRequest("<your service id>")
            {
                Url = "http://productai.cn/img/f10.jpg",

                // this value will be override because you had set the IProfile.GlobalLanguage = LanguageType.Chinese
                Language = LanguageType.English
            };

            //step 4 - send out the request、receive the response、catch the exceptions
            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                // access the reponse directly
                foreach (var r in response.Results)
                {
                    Console.WriteLine("{0}\t\t{1}", r.Url, r.Score);
                }
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
                Console.WriteLine("ClientException happened: \r\n\tRequestId: {0}\r\n\tErrorCode:\r\n\t{1}\r\n\tErrorMessage: {2}",
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

# Support async (支持异步)

```C#
var request = new DetectByImageFileRequest(DetectType.ThreeCAndElectronics)
{
    ImageFile = new System.IO.FileInfo(@".\Detect\iphone.jpg"),
    Language = LanguageType.Chinese
};
var response = await client.GetResponseAsync(request);
```

# Examples （示例）
See project MalongTech.ProductAI.Examples. (请参考工程MalongTech.ProductAI.Examples)

# Release Notes（更新日志）
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
