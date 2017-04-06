using System;
using System.Net;

namespace Qiniu.RPC
{/// <summary>
/// 
/// </summary>
	public class CallRet : EventArgs
	{/// <summary>
    /// 
    /// </summary>
		public HttpStatusCode StatusCode { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
		public Exception Exception { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
		public string Response { get; protected set; }
        /// <summary>
        /// 
        /// </summary>
		public bool OK { get { return (int)StatusCode / 100 == 2; } }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="response"></param>
		public CallRet (HttpStatusCode statusCode, string response)
		{
			StatusCode = statusCode;
			Response = response;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="e"></param>
		public CallRet (HttpStatusCode statusCode, Exception e)
		{
			StatusCode = statusCode;
			Exception = e;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ret"></param>
		public CallRet (CallRet ret)
		{
			StatusCode = ret.StatusCode;
			Exception = ret.Exception;
			Response = ret.Response;
		}
	}
}
