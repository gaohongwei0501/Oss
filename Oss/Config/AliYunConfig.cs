﻿// ------------------------------------------------------------------------------
// Copyright   版权所有。 
// 项目名：Galaxy.AliYunOss 
// 文件名：AliYunConfig.cs
// 创建标识：梁桐铭  2017-03-18 18:18
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Configuration;
using Oss.Util;

namespace Oss.Config
{
    /// <summary>
    /// 阿里云OSS的仓库配置信息
    /// </summary>
    public class AliYunConfig
    {
        #region 暂去除
        //public static readonly string Endpoint = ConfigurationManager.AppSettings["Endpoint"];
        //public static readonly string AccessKeyId = ConfigurationManager.AppSettings["AccessKeyId"];
        //public static readonly string AccessKeySecret = ConfigurationManager.AppSettings["AccessKeySecret"];
        //public static readonly string BucketName = ConfigurationManager.AppSettings["BucketName"];

        //public static readonly string[] ExcExt = BusinessHelper.BreakUpOptions(
        //    ConfigurationManager.AppSettings["ExcExt"],
        //    ','); 
        #endregion

        /// <summary>
        /// Endpoint
        /// </summary>
        public string Endpoint { get; set; }

        /// <summary>
        /// AccessKeyId
        /// </summary>
        public string AccessKeyId { get; set; }

        /// <summary>
        /// AccessKeySecret
        /// </summary>
        public string AccessKeySecret { get; set; }

        /// <summary>
        /// BucketName
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// ExcExt
        /// </summary>
        public string[] ExcExt { get; set; }
    }
}