using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 令牌接口
    /// </summary>
    public interface IToken
    {
        /// <summary>
        /// 获取令牌ID
        /// </summary>
        String TokenID { get; }

        /// <summary>
        /// 获取令牌密钥
        /// </summary>
        String TokenSecret { get; }
    }
}