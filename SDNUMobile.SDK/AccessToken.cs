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
        private UserType _userType;
        private Int32 _expiresIn;
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

        /// <summary>
        /// 获取用户ID
        /// </summary>
        public String UserID
        {
            get { return this._userID; }
        }

        /// <summary>
        /// 获取用户类型
        /// </summary>
        public UserType UserType
        {
            get { return this._userType; }
        }

        /// <summary>
        /// 获取令牌超时时间
        /// </summary>
        public Int32 ExpiresIn
        {
            get { return this._expiresIn; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的访问令牌实体
        /// </summary>
        /// <param name="tokenID">令牌ID</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="expiresIn">令牌超时时间</param>
        public AccessToken(String tokenID, String tokenSecret, String userID, Byte userType, Int32 expiresIn)
        {
            this._tokenID = tokenID;
            this._tokenSecret = tokenSecret;
            this._userID = userID;
            this._userType = (UserType)UserType;
            this._expiresIn = expiresIn;
        }
        #endregion
    }
}