// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：Oss 
// 文件名：QiNiuYunConfigurationSectionHandler.cs
// 创建标识：吴来伟 2017-04-01
// 创建描述：
// 
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using Oss.Config;
using Oss.Util;

namespace Oss.ConfigurationSectionHandler
{
    /// <summary>
    /// 七牛云自定义配置
    /// </summary>
    public class QiNiuYunConfigurationSectionHandler: IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var propertyNodeList = section.SelectNodes("property");
            var propertyData = new Dictionary<string, string>();
            if (propertyNodeList == null) return null;

            foreach (XmlElement propertyNode in propertyNodeList)
            {
                var peopName = propertyNode.GetAttribute("name");
                var peopVal = propertyNode.GetAttribute("value");
                propertyData.Add(peopName, peopVal);
            }

            var qiNiuConfig = new QiNiuConfig();

            qiNiuConfig.AccessKey = propertyData[nameof(qiNiuConfig.AccessKey)];
            qiNiuConfig.BucketName = propertyData[nameof(qiNiuConfig.BucketName)];
            qiNiuConfig.Domain = propertyData[nameof(qiNiuConfig.Domain)];
            qiNiuConfig.RsHost = propertyData[nameof(qiNiuConfig.RsHost)];
            qiNiuConfig.SecretKey = propertyData[nameof(qiNiuConfig.SecretKey)];
            qiNiuConfig.UpHost = propertyData[nameof(qiNiuConfig.UpHost)];


            return qiNiuConfig;
        }
    }
}