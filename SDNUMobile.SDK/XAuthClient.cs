using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// xAuth认证客户端
    /// </summary>
    public class XAuthClient : AbstractClient
    {
        #region 构造方法
        /// <summary>
        /// 初始化新的xAuth认证客户端
        /// </summary>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        public XAuthClient(String consumerKey, String consumerSecret)
            : base(consumerKey, consumerSecret) { }

        /// <summary>
        /// 初始化新的xAuth认证客户端
        /// </summary>
        /// <param name="jsonDeserializer">Json反序列化器</param>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        public XAuthClient(IJsonDeserializer jsonDeserializer, String consumerKey, String consumerSecret)
            : base(jsonDeserializer, consumerKey, consumerSecret) { }

        /// <summary>
        /// 初始化新的xAuth认证客户端
        /// </summary>
        /// <param name="jsonDeserializer">Json反序列化器</param>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="voucher">访问令牌存储凭证</param>
        public XAuthClient(IJsonDeserializer jsonDeserializer, String consumerKey, String consumerSecret, String voucher)
            : base(jsonDeserializer, consumerKey, consumerSecret, voucher) { }
        #endregion
    }
}