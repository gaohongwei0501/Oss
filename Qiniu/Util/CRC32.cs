using System;
using System.IO;

namespace Qiniu.Util
{/// <summary>
/// 
/// </summary>
	public class CRC32
	{/// <summary>
    /// 
    /// </summary>
		public const UInt32 IEEE = 0xedb88320;
        /// <summary>
        /// 
        /// </summary>
		private UInt32[] Table;
        /// <summary>
        /// 
        /// </summary>
		private UInt32 Value;

		/// <summary>
		/// 
		/// </summary>
		public CRC32 ()
		{
			Value = 0;
			Table = MakeTable (IEEE);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
		public void Write (byte[] p, int offset, int count)
		{
			this.Value = Update (this.Value, this.Table, p, offset, count);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public UInt32 Sum32 ()
		{
			return this.Value;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <returns></returns>
		private static UInt32[] MakeTable (UInt32 poly)
		{
			UInt32[] table = new UInt32[256];
			for (int i = 0; i < 256; i++) {
				UInt32 crc = (UInt32)i;
				for (int j = 0; j < 8; j++) {
					if ((crc & 1) == 1)
						crc = (crc >> 1) ^ poly;
					else
						crc >>= 1;
				}
				table [i] = crc;
			}
			return table;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="crc"></param>
        /// <param name="table"></param>
        /// <param name="p"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
		public static UInt32 Update (UInt32 crc, UInt32[] table, byte[] p, int offset, int count)
		{
			crc = ~crc;
			for (int i = 0; i < count; i++) {
				crc = table [((byte)crc) ^ p [offset + i]] ^ (crc >> 8);
			}
			return ~crc;
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
		public static UInt32 CheckSumBytes (byte[] data,int length)
		{
			CRC32 crc = new CRC32 ();
			crc.Write (data, 0, length);
			return crc.Sum32 ();
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
		public static UInt32 CheckSumFile (string fileName)
		{
			CRC32 crc = new CRC32 ();
			int bufferLen = 32 * 1024;
			using (FileStream fs = File.OpenRead(fileName)) {
				byte[] buffer = new byte[bufferLen];
				while (true) {
					int n = fs.Read (buffer, 0, bufferLen);
					if (n == 0)
						break;
					crc.Write (buffer, 0, n);
				}
			}
			return crc.Sum32 ();
		}
	}
}
