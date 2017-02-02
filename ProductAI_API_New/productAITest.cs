using System;
using System.IO;
using System.Collections.Generic;
using ProductAI.API;
namespace ProductAI.Test {
    class ProductAITest {
        static string accessKeyId = "2818bd859cf71c0a88425624fc4f64bc";                           //require: 你的用户配置access_key_id
        static string secretKey =  "4f5df5298197421a22201a2d0d8baffa";                               //require: 你的用户配置secret_key

        static string serviceType ="detect_head";                                   //require: 你的服务类型
        static string serviveId = "_0000041";                                       //require: 你的服务ID
        
        static string imageSetId = "fx84jcav";                                //require: 你的数据集ID

        static ProductAIServiceAPI api =
                new ProductAIServiceAPI(
                    accessKeyId,                                                    //require: 你的用户配置access_key_id
                    secretKey                                                       //require: 你的用户配置secret_key
                    );                             
        
        //static void TestFilePathSearch() {
        //    string filePath = @".\test.jpg";
        //    Dictionary<string,string> options = new Dictionary<string, string>();
        //    options.Add("loc","0-0-1-1");                                           //option: 图片标框的位置信息
        //    options.Add("count","1");

        //    bool isError = true;
        //    string respContent = "";//option: 设置总数限制

        //    isError =
        //        api.SubmitFileToSearch(
        //            serviceType,                                                    //require: 你的服务类型
        //            serviveId,                                                      //require: 你的服务ID
        //            filePath,                                                       //require: 你的本地图片本地路径
        //            options,
        //            out respContent                                                 //请求返回结果获取错误数据
        //            );

        //    if (isError) {
        //        System.Console.WriteLine("request failed!");
        //    } else {
        //        System.Console.WriteLine("request success!");
        //    }
        //    System.Console.WriteLine(respContent);
        //}

        //static void TestFilePathSearchAsync() {
        //    string filePath = @".\test.jpg";

        //    Dictionary<string,string> options = new Dictionary<string, string>();
        //    options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
        //    options.Add("count", "1");                                              //option: 设置总数限制

        //    api.BeginSubmitFileToSearch(
        //        serviceType,                                                        //require: 你的服务类型
        //        serviveId,                                                          //require: 你的服务ID
        //        filePath,                                                           //require: 你的本地图片的路径
        //        options,
        //        RespCallback                                                        //你的异步回调函数
        //        );
        //}
        
        static void TestFileBytesSearch() {
            string filePath = @".\test.jpg";

            Dictionary<string,string> options = new Dictionary<string, string>(); 
            byte[] fileBytes = getFileBytes(filePath);
            options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
            options.Add("count", "1");                                              //option: 设置总数限制

            bool isError = true;
            string respContent = "";

            isError =
                api.SubmitFileToSearch(
                    serviceType,                                                    //require: 你的服务类型
                    serviveId,                                                      //require: 你的服务ID
                    fileBytes,                                                      //require: 你的本地图片二进制数据
                    options ,
                    out respContent
                    );

            if (isError) {
                System.Console.WriteLine("request failed!");
            } else {
                System.Console.WriteLine("request success!");
            }
            System.Console.WriteLine(respContent);
        }

        //static void TestFileBytesSearchAsync() {
        //    string filePath = @".\test.jpg";

        //    Dictionary<string,string> options = new Dictionary<string, string>();
        //    byte[] fileBytes = getFileBytes(filePath);
        //    options.Add("loc", "0-0-1-1");                                          //option: 图片标框的位置信息
        //    options.Add("count", "1");                                              //option: 设置总数限制

        //    api.BeginSubmitFileToSearch(
        //        serviceType,                                                        //require: 你的服务类型
        //        serviveId,                                                          //require: 你的服务ID
        //        fileBytes,                                                          //require: 你的本地图片二进制数据
        //        options,
        //        RespCallback
        //        );
        //}
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

        //static void TestFormSearchAsync() {
        //    string imageUrl = "http://spm-monitor.oss-cn-shanghai.aliyuncs.com/upload-img/services/__all__/2017-01-16/01ce7ac3eeaf6581a4a2429f8fde39837118f80d.jpg";

        //    Dictionary<string,string> options = new Dictionary<string, string>();
        //    options.Add("loc", "0-0-1-1");                                          //option:  图片标框的位置信息                                                                              

        //    api.BeginSubmitFormToSearch(
        //        serviceType,                                                        //require: 你的服务类型
        //        serviveId,                                                          //require: 你的服务ID
        //        imageUrl,                                                           //require: 你的图片链接
        //        options,
        //        RespCallback                                                        //你的异步回调函数
        //        );
        //}

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

        //static void TestAddImageToImageSetAsync() {
        //    string imageUrl = "http://spm-monitor.oss-cn-shanghai.aliyuncs.com/upload-img/services/__all__/2017-01-16/01ce7ac3eeaf6581a4a2429f8fde39837118f80d.jpg";

        //    Dictionary<string,string>  options = new Dictionary<string, string>();
        //    options.Add("meta", "My Test");                                          //option: 附加信息 

        //    api.BeginAddImageToImageSet(
        //        imageSetId,                                                         //require: 你的数据集ID
        //        imageUrl,                                                           //require: 你的图片链接
        //        options,
        //        RespCallback                                                        //你的异步回调函数
        //        );
        //}

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

        //static void TestAddImageByFileAsync() {
        //    string filePath = @".\example.csv";

        //    Dictionary<string ,string> options = new Dictionary<string, string>();

        //    api.BeginAddImageByFile(
        //        imageSetId,                                                         //require: 你的数据集ID                                                    
        //        filePath,                                                           //require: 你的CSV文件的路径
        //        options,
        //        RespCallback                                                        //你的异步回调函数
        //        );
        //}

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

        //static void TestDeleteImageByFileAsync() {
        //    string filePath = @".\example.csv";

        //    Dictionary<string ,string> options = new Dictionary<string, string>();

        //    api.BeginDeleteImageByFile(
        //        imageSetId,                                                         //require: 你的数据集ID                                                    
        //        filePath,                                                           //require: 你的CSV文件的路径
        //        options,
        //        RespCallback                                                        //你的异步回调函数
        //        );                                              
        //}

        //static void RespCallback(IAsyncResult result) {
        //    string respContent =  "";
        //    ProductAIService.ProductAIAsyncResult pAIRes=  
        //        result.AsyncState as ProductAIService.ProductAIAsyncResult;
        //    bool isError = pAIRes.APIInstance.EndRequest(pAIRes, out respContent);

        //    if (isError) {
        //        System.Console.WriteLine("request failed!");
        //    } else {
        //        System.Console.WriteLine("request success!");
        //    }
        //    System.Console.WriteLine(respContent);

        //}

        static protected byte[] getFileBytes(string filePath) {
            byte[] bytes =null;
            if (!File.Exists(filePath)) {
                throw new Exception("File Not find! " + filePath);
            }
            using (FileStream fsSource = new FileStream(filePath,
            FileMode.Open, FileAccess.Read)) {
                bytes = new byte[fsSource.Length];
                int bytesToRead = (int)fsSource.Length;
                int bytesReaded = 0;
                while (bytesToRead > 0) {
                    int n = fsSource.Read(bytes, bytesReaded, bytesToRead);
                    if (0 == n) break;
                    bytesReaded += n;
                    bytesToRead -= n;
                }
            }
            return bytes;
        }

        static void Main(string[] args) {
            //异步操作
            //TestFilePathSearchAsync();
            //TestFileBytesSearchAsync();
            //TestFormSearchAsync();
            //TestDeleteImageByFileAsync();
            //TestAddImageToImageSetAsync();
            //TestAddImageByFileAsync();

            ////同步操作
            //TestFilePathSearch();
            //TestFileBytesSearch();
            //TestFormSearch();
            //TestAddImageToImageSet();
            TestDeleteImageByFile();
            //TestAddImageByFile();
            Console.ReadKey();
        }

    }
}
