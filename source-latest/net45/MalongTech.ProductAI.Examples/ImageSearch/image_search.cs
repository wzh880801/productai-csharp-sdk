using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    class ImageSearchExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 通用图像搜索  <==");
            Console.WriteLine("See https://api-doc.productai.cn/doc/pai.html#通用图像搜索 for details.\r\n");

            //复杂Tag查询示例
            ISearchTag andTag = new AndTag();
            andTag.Add("上衣");
            ISearchTag orTag = new OrTag();
            orTag.Add("蓝色");
            orTag.Add("休闲");
            andTag.Add(orTag);
            ITag searchTag = new SearchTag
            {
                Tag = andTag
            };

            var request = new ImageSearchByImageFileRequest("k7h9fail")
            {
                ImageFile = new System.IO.FileInfo(@".\ContentAnalysis\f10.jpg"),
                Language = LanguageType.Chinese,
                SearchTag = searchTag
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
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