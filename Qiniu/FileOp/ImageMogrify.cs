using System;
using System.Runtime;
using System.Reflection;
using System.Text;

namespace Qiniu.FileOp
{/// <summary>
/// 
/// </summary>
	public class ImageMogrify
	{/// <summary>
    /// 
    /// </summary>
		public bool AutoOrient { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Thumbnail { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Gravity { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Crop { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public int Quality { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public int Rotate { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public string Format { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
		public string MakeRequest (string url)
		{
			string spec = url + "?imageMogr";
			if (AutoOrient)
				spec += "/auto-orient";
			if (!String.IsNullOrEmpty (Thumbnail))
				spec += "/thumbnail/" + Thumbnail;
			if (!String.IsNullOrEmpty (Gravity))
				spec += "/gravity/" + Gravity;
			if (!String.IsNullOrEmpty (Crop))
				spec += "/crop/" + Crop;
			if (Quality != 0)
				spec += "/quality/" + Quality.ToString ();
			if (Rotate != 0)
				spec += "/rotate/" + Rotate.ToString ();
			if (!String.IsNullOrEmpty (Format))
				spec += "/format/" + Format;
			return spec;           
		}
	}
}
