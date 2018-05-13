using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// 场景分析与标注
    /// https://api-doc.productai.cn/doc/pai.html#场景分析与标注
    /// </summary>
    class ClassifyByUrlExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 场景分析与标注  <==");
            Console.WriteLine("See https://api-doc.productai.cn/doc/pai.html#场景分析与标注 for details.\r\n");

            var request = new ClassifyByImageUrlRequest("classify", "_0000039")
            {
                Url = "http://static.esobing.com/images/pai/1.jpg",
                Language = LanguageType.Chinese
            };

            // you can pass the extra paras to the request
            // 如果不需要传递额外的参数，请注释掉如下3行
            request.Options.Add("para1", "1");
            request.Options.Add("para2", "中文");
            request.Options.Add("para3", "value3");

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