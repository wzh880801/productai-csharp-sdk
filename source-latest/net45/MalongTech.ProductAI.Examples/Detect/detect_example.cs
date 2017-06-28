using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// 3C电器检测与定位
    /// https://api-doc.productai.cn/doc/pai.html#3C电器检测与定位
    /// </summary>
    class DetectExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 3C电器检测与定位  <==");
            Console.WriteLine("See https://api-doc.productai.cn/doc/pai.html#3C电器检测与定位 for details.\r\n");

            var request = new DetectByImageFileRequest(DetectType.ThreeCAndElectronics)
            {
                ImageFile = new System.IO.FileInfo(@".\Detect\iphone.jpg"),
                Language = LanguageType.Chinese
            };

            // use image url
            //var request = new Detect3CElectronicsByImageUrlRequest
            //{
            //    Url = "http://productai.cn/img/f12.jpg",
            //    Language = LanguageType.Chinese
            //};

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                foreach (var r in response.DetectedBoxes)
                {
                    Console.WriteLine("{0}\t\t{1}", r.Type, r.Score);
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