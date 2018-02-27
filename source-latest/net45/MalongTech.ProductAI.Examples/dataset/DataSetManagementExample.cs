using System;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// Dataset management apis
    /// 数据集操作: 检索、新增、更新、删除
    /// </summary>
    class DataSetManagementExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 数据集操作  <==");

            Console.WriteLine("==>  Demo - 获取所有数据集  <==");
            GetAll(client);

            Console.WriteLine("==>  Demo - 新增  <==");
            Add(client);

            Console.WriteLine("==>  Demo - 检索  <==");
            Get(client);

            Console.WriteLine("==>  Demo - 更新  <==");
            Update(client);

            Console.WriteLine("==>  Demo - 删除  <==");
            Delete(client);
        }

        private string _dataSetId = "";

        // Add a new dataset 
        // 新增一个数据集
        private void Add(IWebClient client)
        {
            var request = new CreateDataSetRequest
            {
                Name = "MyExampleDs",
                Description = "我的数据集描述-测试"
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("DataSet Id: {0}", response.DataSetId);
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                Console.WriteLine("==========================Result==========================");

                _dataSetId = response.DataSetId;
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

        // get the detail information of a dataset
        // 获取一个数据集的详细信息
        private void Get(IWebClient client)
        {
            var request = new GetDataSetInfoRequest
            {
                DataSetId = _dataSetId
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
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

        // update a existing dataset
        // 更新dataset的信息（名称和描述）
        private void Update(IWebClient client)
        {
            var request = new UpdateDataSetRequest
            {
                Name = "MyDs-Updated",
                Description = "我的数据集描述-测试-Updated",
                DataSetId = _dataSetId
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("LastModifiedTime: {0}", response.LastModifiedTime);
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
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

        // delete a dataset
        // 删除一个数据集
        private void Delete(IWebClient client)
        {
            var request = new DeleteDataSetRequest
            {
                DataSetId = _dataSetId
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
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

        // get all datasets
        // 获取所有的数据集
        private void GetAll (IWebClient client)
        {
            var request = new GetAllDataSetsRequest();

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
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