using System;
using Newtonsoft.Json;

namespace Qiniu.RS
{/// <summary>
/// 
/// </summary>
	public class BatchRetItem
	{/// <summary>
    /// 
    /// </summary>
		public int code;
        /// <summary>
        /// 
        /// </summary>
		public BatchRetData data;
	}
    /// <summary>
    /// 
    /// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public class BatchRetData
	{/// <summary>
    /// 
    /// </summary>
		Int64 fSize;

		/// <summary>
		/// 文件大小.
		/// </summary>
		[JsonProperty("fsize")]
		public Int64 FSize {
			get {
				return fSize;
			}
			set {
				fSize = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
		Int64 putTime;

		/// <summary>
		/// 修改时间.
		/// </summary>
		[JsonProperty("putTime")]
		public Int64 PutTime {
			get {
				return putTime;
			}
			set {
				putTime = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
		string key;

		/// <summary>
		/// 文件名.
		/// </summary>
		[JsonProperty("key")]
		public string Key {
			get {
				return key;
			}
			set {
				key = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
		string hash;

		/// <summary>
		/// Gets a value indicating whether this instance hash.
		/// </summary>
		[JsonProperty("hash")]
		public string Hash {
			get {
				return hash;
			}
			set {
				hash = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
		string mime;

		/// <summary>
		/// Gets the MIME.
		/// </summary>
		[JsonProperty("mimeType")]
		public string Mime {
			get {
				return mime;
			}
			set {
				mime = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
		string endUser;
        /// <summary>
        /// 
        /// </summary>
		public string EndUser {
			get {
				return endUser;
			}
			set {
				endUser = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
		string error;

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("error")]
		public string Error {
			get {
				return error;
			}
			set {
				error = value;
			}
 
		}
	}
}
