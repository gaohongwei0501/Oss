using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using Oss.Response;

namespace Oss.Proxy
{
    public class ProceedeProxy<T> : RealProxy, IProceedeProxy
    {
        private readonly T _decorated;

        public ProceedeProxy(T decorated)
            : base(typeof(T))
        {
            _decorated = decorated;
        }

        /// <summary>
        /// 真实代理
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public override IMessage Invoke(IMessage msg)
        {
            var callmessage = msg as IMethodCallMessage;
            //方法开始
            PreProceede(callmessage);

            try
            {
                //调用真实方法
                var returnValue = callmessage?.MethodBase.Invoke(_decorated, callmessage.Args);
                var response = PostProceede(returnValue);

                var message = new ReturnMessage(
                        response,
                        new object[0],
                        0,
                        null,
                        callmessage);

                return message;
            }
            catch (Exception ex)
            {
                var response = ExceptionProceede(ex);

                return new ReturnMessage(
                            response,
                            new object[0],
                            0,
                            null,
                            callmessage);
            }
        }

        /// <summary>
        /// 执行之前
        /// </summary>
        /// <param name="callMessage"></param>
        public void PreProceede(IMethodCallMessage callMessage)
        {
        }

        /// <summary>
        /// 执行之后
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public object PostProceede(object data)
        {
            return ResponseProvider.Success(data, "成功");
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public object ExceptionProceede(Exception exception)
        {
            return ResponseProvider.Error(exception.InnerException?.Message);
        }
    }
}