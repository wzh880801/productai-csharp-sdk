using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// 时尚分析服务
    /// 时尚智能分析服务可对用户所提交图片中与时尚元素相关的内容进行分析，分析包含：
    ///     1. 找出图中的服饰商品，这些商品的类型及颜色成分；
    ///     2. 判断出图中的服饰、人物所包含的服装款式、图案花型等时尚元素，并以标签的形式返回。
    /// </summary>
    class DressingClassifyByFileExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 时尚分析服务  <==");
            Console.WriteLine("时尚智能分析服务可对用户所提交图片中与时尚元素相关的内容进行分析，分析包含：\r\n");
            Console.WriteLine("    1. 找出图中的服饰商品，这些商品的类型及颜色成分;");
            Console.WriteLine("    2. 判断出图中的服饰、人物所包含的服装款式、图案花型等时尚元素，并以标签的形式返回。");

            var request = new DressingClassifyByImageFileRequest()
            {
                ImageFile = new System.IO.FileInfo(@".\dressing\f10.jpg"),
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