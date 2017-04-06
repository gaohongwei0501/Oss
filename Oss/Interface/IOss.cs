// ------------------------------------------------------------------------------
// Copyright  成都积微物联电子商务有限公司 版权所有。
// 项目名：Galaxy.AliYunOss
// 文件名：Oss.cs
// 创建标识：吴来伟 2017-03-31
// 创建描述：
//
// 修改标识：
// 修改描述：
//  ------------------------------------------------------------------------------

namespace Oss.Interface
{
    /// <summary>
    /// 上传接口
    /// </summary>
    public interface IOss
    {
        /// <summary>
        /// 上传本地文件（本地路径）
        /// </summary>
        /// <param name="key">用于获取阿里云的中图片的唯一值</param>
        /// <param name="fileToUpload">本地路径</param>
        object UpLoad(string key, string fileToUpload);

        /// <summary>
        ///     删除
        /// </summary>
        object Remove(string key);

        /// <summary>
        ///     获取图片
        /// </summary>
        /// <param name="key"></param>
        object Get(string key);

        /// <summary>
        ///     从指定的OSS存储空间中获取指定的文件
        /// </summary>
        /// <param name="key">要获取的文件的名称</param>
        /// <param name="fileToDownload">文件保存的本地路径</param>
        object Down(string key, string fileToDownload);
    }
}