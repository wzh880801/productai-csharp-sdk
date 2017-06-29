using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    class SmartFilterExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 智能滤镜  <==");
            Console.WriteLine("See https://api-doc.productai.cn/doc/pai.html#智能滤镜 for details.\r\n");

            var request = new IntelligentFilterByImageFileRequest()
            {
                ImageFile = new System.IO.FileInfo(@".\Classify\f10.jpg"),
                Language = LanguageType.Chinese,
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                foreach (var r in response.Results)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", r.ImageUrl, r.Score, r.Tag);
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