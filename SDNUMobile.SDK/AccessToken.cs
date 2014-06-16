using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 访问令牌实体
    /// </summary>
    public class AccessToken
    {
        #region 字段
        private String _tokenID;
        private String _tokenSecret;
        private String _userID;
        private Byte _userType;
        private Int32 _expiresIn;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置令牌ID
        /// </summary>
        public String TokenID
        {
            get { return this._tokenID; }
            set { this._tokenID = value; }
        }

        /// <summary>
        /// 获取或设置令牌密钥
        /// </summary>
        public String TokenSecret
        {
            get { return this._tokenSecret; }
            set { this._tokenSecret = value; }
        }

        /// <summary>
        /// 获取或设置用户ID
        /// </summary>
        public String UserID
        {
            get { return this._userID; }
            set { this._userID = value; }
        }

        /// <summary>
        /// 获取或设置用户类型
        /// </summary>
        public Byte UserType
        {
            get { return this._userType; }
            set { this._userType = value; }
        }

        /// <summary>
        /// 获取或设置令牌超时时间
        /// </summary>
        public Int32 ExpiresIn
        {
            get { return this._expiresIn; }
            set { this._expiresIn = value; }
        }
        #endregion
    }
}