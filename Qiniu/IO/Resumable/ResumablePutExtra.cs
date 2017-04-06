using System;
using System.Collections.Specialized;

namespace Qiniu.IO.Resumable
{
	/// <summary>
	/// Block上传成功事件参数
	/// </summary>
	public class PutNotifyEvent:EventArgs
	{/// <summary>
    /// 
    /// </summary>
		int blkIdx;
        /// <summary>
        /// 
        /// </summary>
		public int BlkIdx {
			get { return blkIdx; }
		}
        /// <summary>
        /// 
        /// </summary>
		int blkSize;
        /// <summary>
        /// 
        /// </summary>
		public int BlkSize {
			get { return blkSize; }
		}
        /// <summary>
        /// 
        /// </summary>
		BlkputRet ret;
        /// <summary>
        /// 
        /// </summary>
		public BlkputRet Ret => ret;

	    /// <summary>
        /// 
        /// </summary>
        /// <param name="blkIdx"></param>
        /// <param name="blkSize"></param>
        /// <param name="ret"></param>
		public PutNotifyEvent (int blkIdx, int blkSize, BlkputRet ret)
		{         
			this.blkIdx = blkIdx;
			this.blkSize = blkSize;
			this.ret = ret; 
		}
	}

	/// <summary>
	/// 上传错误事件参数
	/// </summary>
	public class PutNotifyErrorEvent:EventArgs
	{/// <summary>
    /// 
    /// </summary>
		int blkIdx;
        /// <summary>
        /// 
        /// </summary>
		public int BlkIdx {
			get { return blkIdx; }
		}
        /// <summary>
        /// 
        /// </summary>
		int blkSize;
/// <summary>
/// 
/// </summary>
		public int BlkSize => blkSize;
        /// <summary>
        /// 
        /// </summary>
	    string error;
        /// <summary>
        /// 
        /// </summary>
		public string Error {
			get { return error; }           
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blkIdx"></param>
        /// <param name="blkSize"></param>
        /// <param name="error"></param>
		public PutNotifyErrorEvent (int blkIdx, int blkSize, string error)
		{
			this.blkIdx = blkIdx;
			this.blkSize = blkSize;
			this.error = error; 
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class ResumablePutExtra
	{
        /// <summary>
        /// 	//key format as: "x:var"
        /// </summary>
        public NameValueCollection CallbackParams;
        /// <summary>
        /// 
        /// </summary>
		public string CustomMeta;
        /// <summary>
        /// 
        /// </summary>
		public string MimeType;
        /// <summary>
        /// 
        /// </summary>
		public int chunkSize;
        /// <summary>
        /// 
        /// </summary>
		public int tryTimes;
        /// <summary>
        /// /
        /// </summary>
		public BlkputRet[] Progresses;
        /// <summary>
        /// 
        /// </summary>
		public event EventHandler<PutNotifyEvent> Notify;
        /// <summary>
        /// 
        /// </summary>
		public event EventHandler<PutNotifyErrorEvent> NotifyErr;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
		public void OnNotify (PutNotifyEvent arg)
        {
            Notify?.Invoke (this, arg);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
	    public void OnNotifyErr (PutNotifyErrorEvent arg)
		{
			if (NotifyErr != null)
				NotifyErr (this, arg);
		}
	}
}
