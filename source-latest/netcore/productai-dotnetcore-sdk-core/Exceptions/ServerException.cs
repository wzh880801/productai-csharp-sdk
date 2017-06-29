using System;

namespace MalongTech.ProductAI.Core
{
    /// <summary>
    /// Server Exceptions. e.g. Internal Server Error
    /// </summary>
    public class ServerException : ClientException
    {
        public ServerException(string errorCode, string errorMsg) 
            : base(errorCode, errorMsg)
        {

        }
    }
}