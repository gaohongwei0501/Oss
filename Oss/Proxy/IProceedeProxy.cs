using System;
using System.Runtime.Remoting.Messaging;

namespace Oss.Proxy
{
    public interface IProceedeProxy
    {
        /// <summary>
        /// 方法执行之前
        /// </summary>
        /// <param name="callMessage"></param>
        void PreProceede(IMethodCallMessage callMessage);

        /// <summary>
        /// 方法执行之后
        /// </summary>
        /// <param name="data"></param>
        object PostProceede(object data);


        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="exception"></param>
        object ExceptionProceede(Exception exception);


    }
}
