using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity.Color;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// 对图片内容进行色彩分析
    /// </summary>
    class ColorAnalysisByUrlExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 色彩标注服务  <==");

            var request = new ColorClassifyByImageUrlRequest()
            {
                Url = "http://static.esobing.com/images/tooopen_sy_121404229348.jpg",
                Language = LanguageType.Chinese,
                SubType = SubType.EveryThing,
                Granularity = Granularity.Major,
                ReturnType = ColorReturnType.Basic
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
                Console.WriteLine(response.ResponseJsonString);
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