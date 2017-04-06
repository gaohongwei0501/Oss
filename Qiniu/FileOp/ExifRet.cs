using System;
using System.Collections.Generic;
using Qiniu.RPC;
using Newtonsoft.Json;

namespace Qiniu.FileOp
{/// <summary>
/// 
/// </summary>
	public class ExifValType
	{/// <summary>
    /// 
    /// </summary>
		public string val { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public int type { get; set; }
	}
    /// <summary>
    /// 
    /// </summary>
	public class ExifRet : CallRet
	{/// <summary>
    /// 
    /// </summary>
		private Dictionary<string, ExifValType> dict;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
		public ExifValType this [string key] => dict [key];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ret"></param>

		public ExifRet (CallRet ret)
            : base(ret)
		{
			if (!string.IsNullOrEmpty (Response)) {
				try {
					Unmarshal (Response);
				} catch (Exception e) {
					Console.WriteLine (e.ToString ());
					this.Exception = e;
				}
			}
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
		private void Unmarshal (string json)
		{
			dict = JsonConvert.DeserializeObject<Dictionary<string,ExifValType>> (json);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public override string ToString ()
		{
			try {
				return JsonConvert.SerializeObject (dict).ToString ();
			} catch {
				return string.Empty;
			}
		}
	}
}
