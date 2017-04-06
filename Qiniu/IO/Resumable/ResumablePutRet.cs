using System;
using Newtonsoft.Json;

namespace Qiniu.IO.Resumable
{
    /// <summary>
    /// 
    /// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public class BlkputRet
	{/// <summary>
    /// 
    /// </summary>
		[JsonProperty("ctx")]
		public string ctx;
        /// <summary>
        /// 
        /// </summary>
		[JsonProperty("checksum")]
		public string checkSum;
        /// <summary>
        /// 
        /// </summary>
		[JsonProperty("crc32")]
		public UInt32 crc32;
        /// <summary>
        /// 
        /// </summary>
		[JsonProperty("offset")]
		public ulong offset;
	}
}
