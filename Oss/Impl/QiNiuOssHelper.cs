// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。
// 项目名：Oss
// 文件名：QiNiuOssHelper.cs
// 创建标识：吴来伟 2017-04-01
// 创建描述：
//
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------
using Oss.Config;
using Oss.Util;
using Qiniu.IO;
using Qiniu.RS;
using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace Oss.Impl
{
    public class QiNiuOssHelper : ContextBoundObject, Interface.IOss
    {
        private static QiNiuConfig _qiNiuConfig;
        private static readonly IOClient Client = new IOClient();

        private static readonly PutExtra Extra = new PutExtra();

        public QiNiuOssHelper()
        {
            InitConfig();
        }

        /// <summary>
        ///     上传本地文件（本地路径）
        /// </summary>
        /// <param name="key">用于获取阿里云的中图片的唯一值</param>
        /// <param name="fileToUpload">本地路径</param>
        public object UpLoad(string key, string fileToUpload)
        {
            //普通上传,只需要设置上传的空间名就可以了,第二个参数可以设定token过期时间
            var put = new PutPolicy(_qiNiuConfig.BucketName);

            //调用Token()方法生成上传的Token
            var upToken = put.Token();

            //调用PutFile()方法上传
            var putRet = Client.PutFile(upToken, key, fileToUpload, Extra);

            var fielData = new FileData
            {
                Url = _qiNiuConfig.Domain + "/" + putRet.key
            };
            return fielData;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Remove(string key)
        {
            var client = new RSClient();
            var ret = client.Delete(new EntryPath(_qiNiuConfig.BucketName, key));
            if (ret.OK)
            {
                return "删除成功！";
            }

            throw ret.Exception;
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            return _qiNiuConfig.Domain + "/" + key;
        }

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fileToDownload"></param>
        /// <returns></returns>
        public object Down(string key, string fileToDownload)
        {
            var request = (HttpWebRequest)WebRequest.Create(key);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            using (var requestStream = stream)
            {
                var buf = new byte[1024];
                var fs = File.Open(fileToDownload, FileMode.OpenOrCreate);
                var len = 0;
                while (requestStream != null && (len = requestStream.Read(buf, 0, 1024)) != 0)
                    fs.Write(buf, 0, len);
                fs.Close();
            }

            return "成功！";
        }

        #region 初始化方法

        private static void InitConfig()
        {
            _qiNiuConfig= (QiNiuConfig)ConfigurationManager.GetSection("qiNiuYun");

            Qiniu.Conf.Config.ACCESS_KEY = _qiNiuConfig.AccessKey;
            Qiniu.Conf.Config.SECRET_KEY = _qiNiuConfig.SecretKey;
            Qiniu.Conf.Config.UP_HOST = _qiNiuConfig.UpHost;
            Qiniu.Conf.Config.RS_HOST = _qiNiuConfig.RsHost;
        }

        #endregion 初始化方法
    }
}