﻿using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Qiniu.Auth;
using Qiniu.Auth.digest;
using Qiniu.Conf;
using Qiniu.RPC;
using Qiniu.Util;

namespace Qiniu.RS
{
	/// <summary>
	/// 文件管理操作
	/// </summary>
	public enum FileHandle
	{
		/// <summary>
		/// 查看
		/// </summary>
		STAT = 0,
		/// <summary>
		/// 移动move
		/// </summary>
		MOVE,
		/// <summary>
		/// 复制copy
		/// </summary>
		COPY,
		/// <summary>
		/// 删除delete
		/// </summary>
		DELETE,
		/// <summary>
		/// 抓取资源fetch
		/// </summary>
		FETCH
	}

	/// <summary>
	/// 资源存储客户端，提供对文件的查看（stat），移动(move)，复制（copy）,删除（delete）, 抓取资源（fetch） 操作
	/// 以及与这些操作对应的批量操作
	/// </summary>
	public class RSClient : QiniuAuthClient
	{
		private static string[] OPS = new string[] { "stat", "move", "copy", "delete", "fetch" };
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mac"></param>
		public RSClient(Mac mac = null)
			: base(mac)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="op"></param>
		/// <param name="scope"></param>
		/// <returns></returns>
		private CallRet op (FileHandle op, EntryPath scope)
		{
			string url = string.Format ("{0}/{1}/{2}",
			                            Config.RS_HOST,
			                            OPS [(int)op],
			                            Base64URLSafe.Encode (scope.URI));
			return Call (url);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="op"></param>
		/// <param name="pair"></param>
		/// <returns></returns>
		private CallRet op2 (FileHandle op, EntryPathPair pair)
		{
			string url = string.Format ("{0}/{1}/{2}/{3}",
			                            Config.RS_HOST,
			                            OPS [(int)op],
			                            Base64URLSafe.Encode (pair.URISrc),
			                            Base64URLSafe.Encode (pair.URIDest));
			return Call(url);
		}

		private CallRet opFetch(FileHandle op, string fromUrl, EntryPath entryPath)
		{
			string url = string.Format("{0}/{1}/{2}/to/{3}",
										Config.RS_HOST,
										OPS[(int)op],
										Base64URLSafe.Encode(fromUrl),
										Base64URLSafe.Encode(entryPath.URI));
			return Call (url);
		}

		/// <summary>
		/// 文件信息查看
		/// </summary>
		/// <param name="scope"></param>
		/// <returns>文件的基本信息，见<see cref="Entry">Entry</see></returns>
		public Entry Stat (EntryPath scope)
		{
			CallRet callRet = op (FileHandle.STAT, scope);
			return new Entry (callRet);
		}

	    /// <summary>
	    /// 删除文件
	    /// </summary>
	    /// <returns></returns>
	    public CallRet Delete (EntryPath scope)
		{
			CallRet callRet = op (FileHandle.DELETE, scope);
			return new Entry (callRet);
		}

#pragma warning disable CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
	    /// <summary>
	    /// 移动文件
	    /// </summary>
	    /// <param name="bucketSrc">文件所属的源空间名称</param>
	    /// <param name="keySrc">源key</param>
	    /// <param name="bucketDest">目标空间名称</param>
	    /// <param name="keyDest">目标key</param>
	    /// <param name="pathPair"></param>
	    /// <returns>见<see cref="CallRet">CallRet</see></returns>
	    public CallRet Move (EntryPathPair pathPair)
#pragma warning restore CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
        {
			return op2 (FileHandle.MOVE, pathPair);
		}

#pragma warning disable CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
	    /// <summary>
	    /// 复制
	    /// </summary>
	    /// <param name="bucketSrc">文件所属的空间名称</param>
	    /// <param name="keySrc">需要复制的文件key</param>
	    /// <param name="bucketDest">复制至目标空间</param>
	    /// <param name="keyDest">复制的副本文件key</param>
	    /// <param name="pathPair"></param>
	    /// <returns>见<see cref="CallRet">CallRet</see></returns>
	    public CallRet Copy (EntryPathPair pathPair)
#pragma warning restore CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
        {
			return op2 (FileHandle.COPY, pathPair);
		}

		/// <summary>
		/// 抓取资源
		/// </summary>
		/// <param name="fromUrl">需要抓取的文件URL</param>
		/// <param name="entryPath">目标entryPath</param>
		/// <returns>见<see cref="CallRet">CallRet</see></returns>
		public CallRet Fetch(string fromUrl, EntryPath entryPath)
		{
			return opFetch(FileHandle.FETCH, fromUrl, entryPath);
		}

#pragma warning disable CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
	    /// <summary>
	    /// 获取一元批操作http request Body
	    /// </summary>
	    /// <param name="opName">操作名</param>
	    /// <param name="op"></param>
	    /// <param name="keys">操作对象keys</param>
	    /// <returns>Request Body</returns>
	    private string getBatchOp_1 (FileHandle op, EntryPath[] keys)
#pragma warning restore CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
        {
			if (keys.Length < 1)
				return string.Empty;
			StringBuilder sb = new StringBuilder ();
			for (int i = 0; i < keys.Length - 1; i++) {
				string item = string.Format ("op=/{0}/{1}&",
				                             OPS [(int)op], 
				                             Base64URLSafe.Encode (keys [i].URI));
				sb.Append (item);
			}
			string litem = string.Format ("op=/{0}/{1}", OPS [(int)op], Base64URLSafe.Encode (keys [keys.Length - 1].URI));
			return sb.Append (litem).ToString ();
		}

#pragma warning disable CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="opName"></param>
	    /// <param name="op"></param>
	    /// <param name="keys"></param>
	    /// <returns></returns>
	    private string getBatchOp_2 (FileHandle op, EntryPathPair[] keys)
#pragma warning restore CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
        {
			if (keys.Length < 1)
				return string.Empty;
			StringBuilder sb = new StringBuilder ();
			for (int i = 0; i < keys.Length - 1; i++) {
				string item = string.Format ("op=/{0}/{1}/{2}&", 
				                             OPS [(int)op],
				                             Base64URLSafe.Encode (keys [i].URISrc),
				                             Base64URLSafe.Encode (keys [i].URIDest));
				sb.Append (item);
			}
			string litem = string.Format ("op=/{0}/{1}/{2}", OPS [(int)op],
			                              Base64URLSafe.Encode (keys [keys.Length - 1].URISrc),
			                              Base64URLSafe.Encode (keys [keys.Length - 1].URIDest));
			return sb.Append (litem).ToString ();
		}

        private CallRet batch(string requestBody)
        {
            return CallWithBinary(Conf.Config.RS_HOST + "/batch", "application/x-www-form-urlencoded", StreamEx.ToStream(requestBody), requestBody.Length);
        }

#pragma warning disable CS1570 // XML 注释出现 XML 格式错误
                              /// <summary>
                              /// 批操作：文件信息查看
                              /// <example>
                              /// <code>
                              /// public static void BatchStat(string bucket, string[] keys)
                              ///{
                              ///    RSClient client = new RSClient();
                              ///    List<Scope> scopes= new List<Scope>();
                              ///    foreach(string key in keys)
                              ///    {
                              ///        Console.WriteLine("\n===> Stat {0}:{1}", bucket, key);
                              ///        scopes.Add(new Scope(bucket,key));
                              ///    }
                              ///    client.BatchStat(scopes.ToArray()); 
                              ///}
                              /// </code>
                              /// </example>
                              /// </summary>
                              /// <param name="keys">文件bucket+key,see<see cref="Scope"/></param>
                              /// <returns></returns>
        public List<BatchRetItem> BatchStat (EntryPath[] keys)
#pragma warning restore CS1570 // XML 注释出现 XML 格式错误
        {
			string requestBody = getBatchOp_1 (FileHandle.STAT, keys);
			CallRet ret = batch (requestBody);
			if (ret.OK) {
				List<BatchRetItem> items = JsonConvert.DeserializeObject<List<BatchRetItem>> (ret.Response);
				return items;
			}
			return null;
		}

#pragma warning disable CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
	    /// <summary>
	    /// 批操作：文件移动
	    /// </summary>
	    /// <param name="entryPathPair"><see cref="EntryPathPair">EntryPathPair</see></param>
	    /// <param name="entryPathPairs"></param>
	    public CallRet BatchMove (EntryPathPair[] entryPathPairs)
#pragma warning restore CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
        {
			string requestBody = getBatchOp_2 (FileHandle.MOVE, entryPathPairs);
			return batch (requestBody);
		}

#pragma warning disable CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
                              /// <summary>
                              /// 
                              /// </summary>
                              /// <param name="bucket"></param>
                              /// <param name="entryPathPari"></param>
        public CallRet BatchCopy (EntryPathPair[] entryPathPari)
#pragma warning restore CS1572 // XML 注释中有 param 标记，但是没有该名称的参数
        {
			string requestBody = getBatchOp_2 (FileHandle.COPY, entryPathPari);
			return batch (requestBody);
		}

		/// <summary>
		/// 批量删除
		/// </summary>
		/// <param name="keys"></param>
		/// <returns></returns>
		public CallRet BatchDelete (EntryPath[] keys)
		{
			string requestBody = getBatchOp_1 (FileHandle.DELETE, keys);
			return batch (requestBody);
		}
	}
}
