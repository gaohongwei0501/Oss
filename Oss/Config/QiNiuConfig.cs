// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：Oss 
// 文件名：QiNiuConfig.cs
// 创建标识：吴来伟 2017-03-31
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Configuration;

namespace Oss.Config
{
    public class QiNiuConfig
    {
        #region 暂去除
        ///// <summary>
        ///// AccessKey
        ///// </summary>
        //public static readonly string AccessKey = 
        //    ConfigurationManager.AppSettings["AccessKey"];

        ///// <summary>
        ///// SecretKey
        ///// </summary>
        //public static readonly string SecretKey =
        //    ConfigurationManager.AppSettings["SecretKey"]; 

        ///// <summary>
        ///// 存储空间
        ///// </summary>
        //public static readonly string BucketName = 
        //    ConfigurationManager.AppSettings["BucketName"];

        ///// <summary>
        ///// http 镜像资源拉取
        ///// </summary>
        //public static readonly string RsHost =
        //   ConfigurationManager.AppSettings["RsHost"];

        ///// <summary>
        ///// 上传地址（需要针对区域进行配置(例如华南 华东等)）
        ///// </summary>
        //public static readonly string UpHost =
        //  ConfigurationManager.AppSettings["UpHost"]; 

        ///// <summary>
        ///// 域名
        ///// </summary>
        //public static readonly string Domain =
        //  ConfigurationManager.AppSettings["Domain"];  
        #endregion

        /// <summary>
        /// AccessKey
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// SecretKey
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 存储空间
        /// </summary>
        public string BucketName { get; set; }

        /// <summary>
        /// http 镜像资源拉取
        /// </summary>
        public string RsHost { get; set; }

        /// <summary>
        /// 上传地址（需要针对区域进行配置(例如华南 华东等)）
        /// </summary>
        public string UpHost { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }
    }
}