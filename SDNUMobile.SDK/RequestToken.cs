using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 请求令牌实体
    /// </summary>
    public class RequestToken : IToken
    {
        #region 字段
        private String _tokenID;
        private String _tokenSecret;
        #endregion

        #region 属性
        /// <summary>
        /// 获取令牌ID
        /// </summary>
        public String TokenID
        {
            get { return this._tokenID; }
        }

        /// <summary>
        /// 获取令牌密钥
        /// </summary>
        public String TokenSecret
        {
            get { return this._tokenSecret; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的请求令牌实体
        /// </summary>
        /// <param name="tokenID">令牌ID</param>
        /// <param name="tokenSecret">令牌密钥</param>
        public RequestToken(String tokenID, String tokenSecret)
        {
            this._tokenID = tokenID;
            this._tokenSecret = tokenSecret;
        }
        #endregion
    }
}