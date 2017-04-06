using System;
using Qiniu.RPC;

namespace Qiniu.FileOp
{/// <summary>
/// 
/// </summary>
	public static class Exif
	{/// <summary>
    /// 
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
		public static string MakeRequest (string url)
		{
			return url + "?exif";
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
		public static ExifRet Call (string url)
		{
			CallRet callRet = FileOpClient.Get (url);
			return new ExifRet (callRet);
		}
	}
}
