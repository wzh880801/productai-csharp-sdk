using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// 场景分析与标注
    /// https://api-doc.productai.cn/doc/pai.html#场景分析与标注
    /// </summary>
    class ClassifyPlaceExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 场景分析与标注  <==");
            Console.WriteLine("See https://api-doc.productai.cn/doc/pai.html#场景分析与标注 for details.\r\n");

            var request = new ClassifyByImageFileRequest(ClassifyType.Place)
            {
                ImageFile = new System.IO.FileInfo(@".\Classify\f10.jpg"),
                Language = LanguageType.Chinese
            };

            // use image url
            //var request = new PlaceClassifyByImageUrlRequest
            //{
            //    Url = "http://productai.cn/img/f10.jpg",
            //    Language = LanguageType.Chinese
            //};

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                foreach (var r in response.Results)
                {
                    Console.WriteLine("{0}\t\t{1}", r.Category, r.Score);
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