using System;
using System.Text;
using System.Threading.Tasks;

namespace MalongTech.ProductAI.Core
{
    public interface IWebClient
    {
        /// <summary>
        /// Api Host
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// The Encoding used to parse the response content.
        /// Default is UTF8
        /// </summary>
        Encoding ParseEncoding { get; set; }

        /// <summary>
        /// Get or Set your profile
        /// </summary>
        IProfile Profile { get; set; }

        /// <summary>
        /// Get the response synchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        T GetResponse<T>(BaseRequest<T> request)
            where T : BaseResponse;

        /// <summary>
        /// Get the response asynchronously
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<T> GetResponseAsync<T>(BaseRequest<T> request)
            where T : BaseResponse;
    }
}