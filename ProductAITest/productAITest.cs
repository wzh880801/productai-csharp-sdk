using System;
using System.IO;
using System.Collections.Generic;
using ProductAI.API;
namespace ProductAI.Test {
    class ProductAITest {
        static string accessKeyId = "your access key id";                           //require: 你的用户配置access_key_id
        static string secretKey =  "your secret key";                               //require: 你的用户配置secret_key

        static string serviceType ="detect_head";                                   //require: 你的服务类型
        static string serviveId = "_0000041";                                       //require: 你的服务ID
        
        static string imageSetId = "your image set";                                //require: 你的数据集ID
  
        static ProductAIServiceAPI api =
                new API.ProductAIServiceAPI(
                    accessKeyId,                                                    //require: 你的用户配置access_key_id
                    secretKey                                                       //require: 你的用户配置secret_key
                    );

        static void TestFilePathSearch() {
            string filePath = @".\test.jpg";
            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("loc", "0-0-1-1");                                           //option: 图片标框的位置信息
            options.Add("count", "1");

            bool isError = true;
            string respContent = "";

            isError =
                api.SubmitFileToSearch(
                    serviceType,                                                    //require: 你的服务类型
                    serviveId,                                                      //require: 你的服务ID
                    filePath,                                                       //require: 你的本地图片本地路径
                    options,
                    out respContent                                                 //请求返回结果获取错误数据
                    );

            if (isError) {
                System.Console.WriteLine("request failed!");
            } else {
                System.Console.WriteLine("request success!");
            }
            System.Console.WriteLine(respContent);
        }

        static void TestFilePathSearchAsync() {
            string filePath = @".\test.jpg";

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
            options.Add("count", "1");                                              //option: 设置总数限制

            api.SubmitFileToSearchAsync(
                serviceType,                                                        //require: 你的服务类型
                serviveId,                                                          //require: 你的服务ID
                filePath,                                                           //require: 你的本地图片的路径
                options,
                TestCallback                                                        //你的异步回调函数
                );
        }

        static void TestFileBytesSearch() {
            string filePath = @".\test.jpg";

            Dictionary<string, string> options = new Dictionary<string, string>();
            byte[] fileBytes = Functions.getFileBytes(filePath);
            options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
            options.Add("count", "1");                                              //option: 设置总数限制

            bool isError = true;
            string respContent = "";

            isError =
                api.SubmitFileToSearch(
                    serviceType,                                                    //require: 你的服务类型
                    serviveId,                                                      //require: 你的服务ID
                    fileBytes,                                                      //require: 你的本地图片二进制数据
                    options,
                    out respContent
                    );

            if (isError) {
                System.Console.WriteLine("request failed!");
            } else {
                System.Console.WriteLine("request success!");
            }
            System.Console.WriteLine(respContent);
        }

        static void TestFileBytesSearchAsync() {
            string filePath = @".\test.jpg";

            Dictionary<string, string> options = new Dictionary<string, string>();
            byte[] fileBytes = Functions.getFileBytes(filePath);
            options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
            options.Add("count", "1");                                              //option: 设置总数限制

            api.SubmitFileToSearchAsync(
                serviceType,                                                        //require: 你的服务类型
                serviveId,                                                          //require: 你的服务ID
                fileBytes,                                                          //require: 你的本地图片二进制数据
                options,
                TestCallback
                );
        }
        static void TestFormSearch() {
            string imageUrl = "http://spm-monitor.oss-cn-shanghai.aliyuncs.com/upload-img/services/__all__/2017-01-16/01ce7ac3eeaf6581a4a2429f8fde39837118f80d.jpg";

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("loc", "0-0-1-1");                                          //option:  图片标框的位置信息

            bool isError = true;
            string respContent = "";

            isError = api.SubmitFormToSearch(
                serviceType,                                                        //require: 你的服务类型
                serviveId,                                                          //require: 你的服务ID
                imageUrl,                                                           //require: 你的图片链接
                options,
                out respContent
                );

            if (isError) {
                System.Console.WriteLine("request failed!");
            } else {
                System.Console.WriteLine("request success!");
            }
            System.Console.WriteLine(respContent);
        }

        static void TestFormSearchAsync() {
            string imageUrl = "http://spm-monitor.oss-cn-shanghai.aliyuncs.com/upload-img/services/__all__/2017-01-16/01ce7ac3eeaf6581a4a2429f8fde39837118f80d.jpg";

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("loc", "0-0-1-1");                                          //option:  图片标框的位置信息                                                                              

            api.SubmitFormToSearchAsync(
                serviceType,                                                        //require: 你的服务类型
                serviveId,                                                          //require: 你的服务ID
                imageUrl,                                                           //require: 你的图片链接
                options,
                TestCallback                                                        //你的异步回调函数
                );
        }

        static void TestAddImageToImageSet() {
            string imageUrl = "http://spm-monitor.oss-cn-shanghai.aliyuncs.com/upload-img/services/__all__/2017-01-16/01ce7ac3eeaf6581a4a2429f8fde39837118f80d.jpg";

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("meta", "My Test");                                          //option: 附加信息

            bool isError = true;
            string respContent = "";

            isError = api.AddImageToImageSet(
                imageSetId,                                                         //require: 你的数据集ID
                imageUrl,                                                           //require: 你的图片链接
                options,
                out respContent
                );

            if (isError) {
                System.Console.WriteLine("request failed!");
            } else {
                System.Console.WriteLine("request success!");
            }
            System.Console.WriteLine(respContent);

        }

        static void TestAddImageToImageSetAsync() {
            string imageUrl = "http://spm-monitor.oss-cn-shanghai.aliyuncs.com/upload-img/services/__all__/2017-01-16/01ce7ac3eeaf6581a4a2429f8fde39837118f80d.jpg";

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("meta", "My Test");                                          //option: 附加信息 

            api.AddImageToImageSetAsync(
                imageSetId,                                                         //require: 你的数据集ID
                imageUrl,                                                           //require: 你的图片链接
                options,
                TestCallback                                                        //你的异步回调函数
                );
        }

        static void TestAddImageByFile() {
            string filePath = @".\example.csv";

            Dictionary<string, string> options = new Dictionary<string, string>();

            bool isError = true;
            string respContent = "";

            isError = api.AddImageByFile(
                imageSetId,                                                         //require: 你的数据集ID
                filePath,                                                           //require: 你的CSV文件的路径
                options,
                out respContent
                );

            if (isError) {
                System.Console.WriteLine("request failed!");
            } else {
                System.Console.WriteLine("request success!");
            }

            System.Console.WriteLine(respContent);
        }

        static void TestAddImageByFileAsync() {
            string filePath = @".\example.csv";

            Dictionary<string, string> options = new Dictionary<string, string>();

            api.AddImageByFileAsync(
                imageSetId,                                                         //require: 你的数据集ID                                                    
                filePath,                                                           //require: 你的CSV文件的路径
                options,
                TestCallback                                                        //你的异步回调函数
                );
        }

        static void TestDeleteImageByFile() {
            string filePath = @".\example.csv";

            Dictionary<string, string> options = new Dictionary<string, string>();

            bool isError = true;
            string respContent = "";

            isError = api.DeleteImageByFile(
                imageSetId,                                                         //require: 你的数据集ID
                filePath,                                                           //require: 你的CSV文件的路径
                options,
                out respContent
                );

            if (isError) {
                System.Console.WriteLine("request failed!");
            } else {
                System.Console.WriteLine("request success!");
            }
            System.Console.WriteLine(respContent);
        }

        static void TestDeleteImageByFileAsync() {
            string filePath = @".\example.csv";

            Dictionary<string, string> options = new Dictionary<string, string>();

            api.DeleteImageByFileAsync(
                imageSetId,                                                         //require: 你的数据集ID                                                    
                filePath,                                                           //require: 你的CSV文件的路径
                options,
                TestCallback                                                        //你的异步回调函数
                );
        }
        static protected void TestCallback(bool isErr, string res) {
            if (isErr) {
                System.Console.WriteLine("request failed!");
            } else {
                System.Console.WriteLine("request success!");
            }
            System.Console.WriteLine(res);
        }

        static void Main(string[] args) {
            //异步操作
            TestFilePathSearchAsync();
            TestFileBytesSearchAsync();
            TestFormSearchAsync();
            TestDeleteImageByFileAsync();
            TestAddImageToImageSetAsync();
            TestAddImageByFileAsync();

            //同步操作
            TestAddImageByFile();
            TestFilePathSearch();
            TestFileBytesSearch();
            TestFormSearch();
            TestAddImageToImageSet();
            TestDeleteImageByFile();
            TestAddImageByFile();
            Console.ReadKey();
        }

    }
}
