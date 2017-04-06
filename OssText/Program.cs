using System;
using Oss;

namespace OssText
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //新增
            var key = Guid.NewGuid().ToString() + ".txt";
            var fileToUpload = "C:\\Users\\PCWULAIWEI\\Desktop\\新建文本文档(2).txt";
            #region QiNiu

            //var oss = OssFactory.CreateInstance("QiNiu");
            //var info = oss.UpLoad(key, fileToUpload);
            //var url = oss.Get(key);

            //删除
            //var key = "15607622-5159-401d-8da8-e464bfb213ab.png";
            //var info= oss.Remove(key);

            //下载
            //var key = "http://onjyr6lwp.bkt.clouddn.com/2fc99536-0141-43f2-85ba-9012e3146795.png";
            //var fileToDownUpload = "C:\\Users\\PCWULAIWEI\\Desktop\\xxxx.png";
            //var info = OssFactory.CreateInstance("QiNiu").Down(key, fileToDownUpload); 
            #endregion


            var oss = OssFactory.CreateInstance("AliYun");
            var info= oss.UpLoad(key, fileToUpload);

            Console.ReadKey();
        }
    }
}