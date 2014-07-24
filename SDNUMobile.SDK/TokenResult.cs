using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 令牌请求结果类
    /// </summary>
    public class TokenResult
    {
        #region 字段
        private Boolean _success;
        private IToken _token;
        private OAuthError _error;
        #endregion

        #region 属性
        /// <summary>
        /// 获取执行是否成功
        /// </summary>
        public Boolean Success
        {
            get { return this._success; }
        }

        /// <summary>
        /// 获取获取到的令牌
        /// </summary>
        public IToken Token
        {
            get { return this._token; }
        }

        /// <summary>
        /// 获取错误实体（如果存在）
        /// </summary>
        public OAuthError Error
        {
            get { return this._error; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的令牌请求结果类
        /// </summary>
        /// <param name="token">令牌实体</param>
        public TokenResult(IToken token)
        {
            this._success = true;
            this._token = token;
            this._error = null;
        }

        /// <summary>
        /// 初始化新的令牌请求结果类
        /// </summary>
        /// <param name="error">错误实体</param>
        public TokenResult(OAuthError error)
        {
            this._success = false;
            this._token = null;
            this._error = error;
        }
        #endregion
    }
}