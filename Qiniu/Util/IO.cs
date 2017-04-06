using System;
using System.Text;
using System.IO;

namespace Qiniu.Util
{/// <summary>
/// 
/// </summary>
    public static class IO
    {/// <summary>
    /// 
    /// </summary>
        public static int bufferLen = 32*1024;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="src"></param>
        public static void Copy(Stream dst, Stream src)
        {
			long l  =src.Position;
            byte[] buffer = new byte[bufferLen];
            while (true)
            {
                int n = src.Read(buffer, 0, bufferLen);
                if (n == 0) break;
                dst.Write(buffer, 0, n);
            }
			src.Seek (l, SeekOrigin.Begin);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="src"></param>
        /// <param name="numBytesToCopy"></param>
        public static void CopyN(Stream dst, Stream src, long numBytesToCopy)
        {
			long l  =src.Position;
            byte[] buffer = new byte[bufferLen];
            long numBytesWritten = 0;
            while (numBytesWritten < numBytesToCopy)
            {
                int len = bufferLen;
                if ((numBytesToCopy - numBytesWritten) < len)
                {
                    len = (int)(numBytesToCopy - numBytesWritten);
                }
                int n = src.Read(buffer, 0, len);
                if (n == 0) break;
                dst.Write(buffer, 0, n);
                numBytesWritten += n;
            }
			src.Seek (l, SeekOrigin.Begin);
            if (numBytesWritten != numBytesToCopy)
            {
                throw new Exception("StreamUtil.CopyN: nwritten not equal to ncopy");
            }
        }
    }
}
