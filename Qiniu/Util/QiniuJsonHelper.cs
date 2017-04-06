using Newtonsoft.Json;


namespace Qiniu.Util
{/// <summary>
/// 
/// </summary>
	public static class QiniuJsonHelper
	{/// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
		public static string JsonEncode (object obj)
		{
			JsonSerializerSettings setting = new JsonSerializerSettings ();
			setting.NullValueHandling = NullValueHandling.Ignore;
			return JsonConvert.SerializeObject (obj, setting);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
		public static T ToObject<T> (string value)
		{
			return JsonConvert.DeserializeObject<T> (value);
		}
	}
}
