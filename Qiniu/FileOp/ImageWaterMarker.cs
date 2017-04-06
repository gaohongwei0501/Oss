using System;
using System.Text;
using Qiniu.Util;

namespace Qiniu.FileOp
{/// <summary>
/// 
/// </summary>
	public class ImageWaterMarker:WaterMarker
	{/// <summary>
    /// 
    /// </summary>
		public string imageUrl;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="dissolve"></param>
        /// <param name="gravity"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
		public ImageWaterMarker (string imageUrl, int dissolve=50, MarkerGravity gravity = MarkerGravity.SouthEast, int dx = 10, int dy = 10)
            : base(dissolve,gravity, dx, dy)
		{
			this.imageUrl = imageUrl;            
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
		public override string MakeRequest (string url)
		{
			StringBuilder sb = new StringBuilder ();
			sb.Append ($"{url}?watermark/{1}");
			if (string.IsNullOrEmpty (imageUrl)) {
				throw new Exception ("Water Marker Image Url Error");
			}            
			sb.Append ("/image/" + Base64URLSafe.ToBase64URLSafe(imageUrl));
			sb.Append ("/dissolve/" + dissolve);
			sb.Append ("/gravity/" + Gravitys [(int)gravity]);
			sb.Append ("/dx/" + dx);
			sb.Append ("/dy/" + dy);
			return sb.ToString ();            
		}
	}
}
