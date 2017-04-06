using System;
using System.Text;
using Qiniu.Util;

namespace Qiniu.FileOp
{
    /// <summary>
    /// 
    /// </summary>
    public class TextWaterMarker : WaterMarker
    {/// <summary>
    /// 
    /// </summary>
        private string text;
        /// <summary>
        /// 
        /// </summary>
        private string fontName;
        /// <summary>
        /// 
        /// </summary>
        private int fontSize;
        /// <summary>
        /// 
        /// </summary>
        private string color;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontname"></param>
        /// <param name="color"></param>
        /// <param name="fontsize"></param>
        /// <param name="dissolve"></param>
        /// <param name="gravity"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        public TextWaterMarker(string text, string fontname = "", string color = "", int fontsize = 0, int dissolve = 50, MarkerGravity gravity = MarkerGravity.SouthEast, int dx = 10, int dy = 10)
            : base(dissolve, gravity, dx, dy)
        {
            this.text = text;
            this.fontName = fontname;
            this.fontSize = fontsize;
            this.color = color;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public override string MakeRequest(string url)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0}?watermark/{1}", url, 2));
            if (string.IsNullOrEmpty(text))
            {
                throw new Exception("No Text To Draw");
            }
            sb.Append("/text/" + Base64URLSafe.ToBase64URLSafe(text));

            if (!string.IsNullOrEmpty(fontName))
            {
                sb.Append("/font/" + Base64URLSafe.ToBase64URLSafe(fontName));
            }
            if (fontSize > 0)
            {
                sb.Append("/fontsize/" + fontSize);
            }
            if (!string.IsNullOrEmpty(color))
            {
                sb.Append("/fill/" + Base64URLSafe.ToBase64URLSafe(color));
            }
            sb.Append("/dissolve/" + dissolve);
            sb.Append("/gravity/" + Gravitys[(int)gravity]);
            sb.Append("/dx/" + dx);
            sb.Append("/dy/" + dy);
            return sb.ToString();
        }
    }
}
