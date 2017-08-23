using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// 数据集操作
    /// https://api-doc.productai.cn/doc/pai.html#向数据集增加单条数据
    /// </summary>
    class DataSeSingleAddExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 数据集操作  <==");
            Console.WriteLine("See https://api-doc.productai.cn/doc/pai.html#向数据集增加单条数据 for details.\r\n");

            var request = new DataSetSingleAddByImageUrlRequest("lqn2jj6z")
            {
                ImageUrl = "http://static.esobing.com/images/dog.jpg"
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("LastModifiedTime: {0}", response.LastModifiedTime);
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