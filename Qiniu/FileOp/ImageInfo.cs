using System;
using Qiniu.RPC;

namespace Qiniu.FileOp
{/// <summary>
/// 
/// </summary>
	public static class ImageInfo
	{/// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
		public static string MakeRequest (string url)
		{
			return url + "?imageInfo";
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
		public static ImageInfoRet Call (string url)
		{
			CallRet callRet = FileOpClient.Get (url);
			return new ImageInfoRet (callRet);
		}
	}
}
