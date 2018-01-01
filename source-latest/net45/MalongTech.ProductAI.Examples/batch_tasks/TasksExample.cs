using System;
using System.Collections.Generic;
using MalongTech.ProductAI.Core;
using MalongTech.ProductAI.API.Entity;
using MalongTech.ProductAI.API.Entity.Batch;

namespace MalongTech.ProductAI.Examples
{
    /// <summary>
    /// Batch API Example
    /// 批处理任务API操作示例
    /// </summary>
    class TasksExample : IExample
    {
        public void Run(IWebClient client)
        {
            Console.WriteLine("==>  Demo - 批处理操作  <==");

            Console.WriteLine("==>  Demo - 获取批量任务列表  <==");
            SearchTasks(client);

            Console.WriteLine("==>  Demo - 获取支持服务列表  <==");
            GetSupportServiceIds(client);

            Console.WriteLine("==>  Demo - 通过CSV文件（一行一个URL）创建批量任务  <==");
            var task_id = CreateTaskByCsvFile(client);

            Console.WriteLine("==>  Demo - 启动批量任务  <==");
            if (!string.IsNullOrWhiteSpace(task_id))
                StartTask(client, task_id);

            Console.WriteLine("==>  Demo - 查询批量任务进度  <==");
            if (!string.IsNullOrWhiteSpace(task_id))
                WaitForTaskToCompleted(client, task_id);

            Console.WriteLine("==>  Demo - 取消批量任务  <==");
            // CancelTask(client, task_id);
        }

        // Get all support service ids
        // 获取所有支持批处理的服务
        private void GetSupportServiceIds(IWebClient client)
        {
            var request = new GetSupportServicesRequest();

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                foreach(var service_id in response.SupportServiceIds)
                {
                    Console.WriteLine(service_id);
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

        // Create Task by CSV file
        // 通过CSV文件创建批处理任务
        private string CreateTaskByCsvFile(IWebClient client)
        {
            var request = new CreateTaskByFileRequest
            {
                ServiceId = "_0000039",
                CsvFile = new System.IO.FileInfo(@".\batch_tasks\urls-001.csv")
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                if (response.TaskInfo != null)
                {
                    Console.WriteLine("Task id is: {0}", response.TaskInfo.TaskId);
                    return response.TaskInfo.TaskId;
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

            return "";
        }

        // Start Task
        // 启动任务
        private void StartTask(IWebClient client, string task_id)
        {
            var request = new StartTaskRequest
            {
                TaskId = task_id
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                if (response.TaskInfo != null)
                    Console.WriteLine("Task id is: {0}", response.TaskInfo.TaskId);
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

        // Poll task status
        // 获取任务状态
        private void WaitForTaskToCompleted(IWebClient client, string task_id)
        {
            var request = new PollTaskStatusRequest
            {
                TaskId = task_id
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                while (response.TaskInfo.TaskStatus != TaskStatus.FAILURE & response.TaskInfo.TaskStatus != TaskStatus.SUCCESS)
                {
                    Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                    System.Threading.Thread.Sleep(5000);
                    response = client.GetResponse(request);
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

        // Cancel Task
        // 取消任务
        // 只有任务在队列中（状态字段state为PENDING）时，任务可以被取消．一旦任务开始运行，则不可被取消．
        private void CancelTask(IWebClient client, string task_id)
        {
            var request = new CancelTaskRequest
            {
                TaskId = task_id
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

        // Search Tasks
        private string SearchTasks(IWebClient client)
        {
            var request = new SearchTaskRequest
            {
                StartDate = null,
                EndDate = DateTime.Now.AddDays(1).Date
            };

            try
            {
                var response = client.GetResponse(request);

                Console.WriteLine("==========================Result==========================");
                Console.WriteLine("Response: \r\n{0}", response.ResponseJsonString);
                foreach(string key in response.Tasks.Keys)
                {
                    Console.WriteLine("{0}:{1}", key, Newtonsoft.Json.JsonConvert.SerializeObject(response.Tasks[key]));
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

            return "";
        }
    }
}