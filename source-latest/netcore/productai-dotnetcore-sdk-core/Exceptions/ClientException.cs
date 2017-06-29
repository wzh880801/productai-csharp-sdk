using System;

namespace MalongTech.ProductAI.Core
{
    /// <summary>
    /// Client Exception. 
    /// This means that something was wrong when you are calling the service.
    /// For example, you specified a invalid profile.
    /// </summary>
    public class ClientException : Exception
    {
        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public string RequestId { get; set; }

        public ClientException(string errCode, string errMsg, string requestId)
            : this(errCode, errMsg)
        {
            RequestId = requestId;
        }

        public ClientException(string errCode, string errMsg)
            : this(errCode + " : " + errMsg)
        {
            ErrorCode = errCode;
            ErrorMessage = errMsg;
        }

        public ClientException(string message)
            : base(message)
        {

        }
    }
}