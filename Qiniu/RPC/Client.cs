using System;
using System.IO;
using System.Net;

namespace Qiniu.RPC
{/// <summary>
/// 
/// </summary>
	public class Client
	{       /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="body"></param>
		public virtual void SetAuth (HttpWebRequest request, Stream body)
		{
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
		public CallRet Call (string url)
		{
			Console.WriteLine ("Client.Post ==> URL: " + url);
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);
				request.UserAgent = Conf.Config.USER_AGENT;
				request.Method = "POST";                
				SetAuth (request, null);
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
					return HandleResult (response);
				}
			} catch (Exception e) {
				Console.WriteLine (e.ToString ());
				return new CallRet (HttpStatusCode.BadRequest, e);
			}
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="contentType"></param>
        /// <param name="body"></param>
        /// <param name="length"></param>
        /// <returns></returns>
		public CallRet CallWithBinary (string url, string contentType, Stream body, long length)
		{
			Console.WriteLine ("Client.PostWithBinary ==> URL: {0} Length:{1}", url, length);
			try {
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url);
				request.UserAgent = Conf.Config.USER_AGENT;
				request.Method = "POST";
				request.ContentType = contentType;
				request.ContentLength = length;
				SetAuth (request, body);
				using (Stream requestStream = request.GetRequestStream()) {
					Util.IO.CopyN (requestStream, body, length);
				}
				using (HttpWebResponse response = request.GetResponse() as HttpWebResponse) {
					return HandleResult (response);
				}
			} catch (Exception e) {
				Console.WriteLine (e.ToString ());
				return new CallRet (HttpStatusCode.BadRequest, e);
			}
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
		public static CallRet HandleResult (HttpWebResponse response)
		{
			HttpStatusCode statusCode = response.StatusCode;
			using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
				string responseStr = reader.ReadToEnd ();
				return new CallRet (statusCode, responseStr);
			}
		}
	}
}