// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。
// 项目名：Galaxy.AliYunOss
// 文件名：OssHelper.cs
// 创建标识：吴来伟 2017-03-31
// 创建描述：
//
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using Aliyun.OSS;
using Oss.Util;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Oss.Config;

namespace Oss.Impl
{
    public class AliyunOssHelper : ContextBoundObject, Interface.IOss
    {
        private static  AliYunConfig _aliYunConfig;
        private static OssClient _client;
        public AliyunOssHelper()
        {
            InitConfig();
            _client= new OssClient(
                _aliYunConfig.Endpoint,
                _aliYunConfig.AccessKeyId,
                _aliYunConfig.AccessKeySecret);

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        private void InitConfig()
        {
            _aliYunConfig= (AliYunConfig)ConfigurationManager.GetSection("aliYun");
        }

        /// <summary>
        ///     上传本地文件（本地路径）
        /// </summary>
        /// <param name="key">用于获取阿里云的中图片的唯一值</param>
        /// <param name="fileToUpload">本地路径</param>
        public object UpLoad(string key, string fileToUpload)
        {
            var filePath = $"{key}"; //云文件保存路径

            _client.PutObject(_aliYunConfig.BucketName, filePath, fileToUpload);
            var fielData = new FileData
            {
                Url = _aliYunConfig.BucketName + "." + _aliYunConfig.Endpoint + "/" + filePath
            };
            return fielData;
        }

        /// <summary>
        ///     删除
        /// </summary>
        public object Remove(string key)
        {
            var listResult = _client.ListObjects(_aliYunConfig.BucketName);
            var ossObjectSummaries = listResult.ObjectSummaries.FirstOrDefault(x => x.Key == key);
            if (ossObjectSummaries != null)
                _client.DeleteObject(_aliYunConfig.BucketName, ossObjectSummaries.Key);
            return "删除成功！";
        }

        /// <summary>
        ///     获取图片
        /// </summary>
        /// <param name="key"></param>
        public object Get(string key)
        {
            var req = new GeneratePresignedUriRequest(_aliYunConfig.BucketName, key, SignHttpMethod.Get)
            {
                Expiration = DateTime.Now.AddHours(1)
            };
            return _client.GeneratePresignedUri(req);
        }

        /// <summary>
        ///     从指定的OSS存储空间中获取指定的文件
        /// </summary>
        /// <param name="key">要获取的文件的名称</param>
        /// <param name="fileToDownload">文件保存的本地路径</param>
        public object Down(string key, string fileToDownload)
        {
            var info = _client.GetObject(_aliYunConfig.BucketName, key);
            using (var requestStream = info.Content)
            {
                var buf = new byte[1024];
                var fs = File.Open(fileToDownload, FileMode.OpenOrCreate);
                var len = 0;
                while ((len = requestStream.Read(buf, 0, 1024)) != 0)
                    fs.Write(buf, 0, len);
                fs.Close();
            }
            return "成功！";
        }
    }
}