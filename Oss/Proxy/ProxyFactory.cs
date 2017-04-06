using System;

namespace Oss.Proxy
{
    public class ProxyFactory
    {
        public static T Create<T>()
        {
            //创建真实实例  
            var instance = Activator.CreateInstance<T>();

            //创建真实代理  
            var realProxy = new ProceedeProxy<T>(instance);
            var transparentProxy = (T)realProxy.GetTransparentProxy();

            //返回透明代理  
            return transparentProxy;
        }
    }
}
