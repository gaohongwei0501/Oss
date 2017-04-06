using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oss.Impl;
using Oss.Interface;
using Oss.Proxy;

namespace Oss
{
    /// <summary>
    /// Oss工厂
    /// </summary>
    public class OssFactory
    {
        /// <summary>
        ///     创建实例
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IOss CreateInstance(string key)
        {
            switch (key)
            {
                case "AliYun":
                    return ProxyFactory.Create<AliyunOssHelper>();
                case "QiNiu":
                    return ProxyFactory.Create<QiNiuOssHelper>();
                default:
                    return null;
            }
        }
    }
}
