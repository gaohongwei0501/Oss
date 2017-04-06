using Qiniu.RPC;

namespace Qiniu.FileOp
{/// <summary>
/// 
/// </summary>
	public enum MarkerGravity
	{/// <summary>
    /// 
    /// </summary>
		NorthWest = 0,
        /// <summary>
        /// 
        /// </summary>
		North,
        /// <summary>
        /// 
        /// </summary>
		NorthEast,
        /// <summary>
        /// 
        /// </summary>
		West,
        /// <summary>
        /// 
        /// </summary>
		Center,
        /// <summary>
        /// 
        /// </summary>
		East,
        /// <summary>
        /// 
        /// </summary>
		SouthWest,
        /// <summary>
        /// 
        /// </summary>
        South,
        /// <summary>
        /// 
        /// </summary>
		SouthEast
	}
    /// <summary>
    /// 
    /// </summary>
	public class WaterMarker
	{/// <summary>
    /// 
    /// </summary>
		protected static string[] Gravitys = new string[9] {
			"NorthWest",
			"North",
			"NorthEast",
			"West",
			"Center",
			"East",
			"SouthWest",
			"South",
			"SouthEast"
		};/// <summary>
        /// 
        /// </summary>
		protected int dx;
        /// <summary>
        /// 
        /// </summary>
		protected int dy;
        /// <summary>
        /// 
        /// </summary>
		protected int dissolve;
        /// <summary>
        /// 
        /// </summary>
		public int Dissolve {
			get { return dissolve; }
			set {
				if (value < 0)
					dissolve = 0;
				else if (value > 100)
					dissolve = 100;
				else
					dissolve = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
		public MarkerGravity gravity;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dissolve"></param>
        /// <param name="gravity"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
		public WaterMarker (int dissolve = 50, MarkerGravity gravity = MarkerGravity.SouthEast, int dx = 10, int dy = 10)
		{
			Dissolve = dissolve;
			this.dissolve = dissolve;
			this.dx = dx;
			this.dy = dy;
			this.gravity = gravity;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
		public virtual string MakeRequest (string url)
		{
			return null;
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
