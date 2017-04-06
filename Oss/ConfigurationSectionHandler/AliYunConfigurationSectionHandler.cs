// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。 
// 项目名：Oss 
// 文件名：AliYunConfigurationSectionHandler.cs
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
    /// 阿里云自定义配置
    /// </summary>
    public class AliYunConfigurationSectionHandler: IConfigurationSectionHandler
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

            var aliYunConfig = new AliYunConfig();

            aliYunConfig.AccessKeyId = propertyData[nameof(aliYunConfig.AccessKeyId)];
            aliYunConfig.AccessKeySecret = propertyData[nameof(aliYunConfig.AccessKeySecret)];
            aliYunConfig.BucketName = propertyData[nameof(aliYunConfig.BucketName)];
            aliYunConfig.Endpoint = propertyData[nameof(aliYunConfig.Endpoint)];
            aliYunConfig.ExcExt = BusinessHelper.BreakUpOptions(
                                propertyData[nameof(aliYunConfig.ExcExt)],
                             ',');

            return aliYunConfig;
        }
    }
}