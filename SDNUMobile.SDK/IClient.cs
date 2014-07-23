using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 客户端接口
    /// </summary>
    public interface IClient
    {
        #region 属性
        /// <summary>
        /// 获取当前客户端Key
        /// </summary>
        String ConsumerKey { get; }

        /// <summary>
        /// 获取当前客户端密钥
        /// </summary>
        String ConsumerSecret { get; }

        /// <summary>
        /// 获取当前访问令牌
        /// </summary>
        AccessToken AccessToken { get; }
        #endregion

        #region 方法
        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数</param>
        /// <exception cref="NullReferenceException">访问令牌不能为空</exception>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        void RequestRestMethodAsync(AbstractRestMethod restMethod, Action<RestResult> callback);
        #endregion
    }
}