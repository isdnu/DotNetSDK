using System;
using System.Globalization;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 访问令牌实体
    /// </summary>
    public class AccessToken : IToken
    {
        #region 常量
        private const String DateTimeStringFormat = "yyyy-MM-dd HH:mm:ss";
        #endregion

        #region 字段
        private String _tokenID;
        private String _tokenSecret;
        private String _userID;
        private UserType _userType;
        private Int32 _expiresIn;
        private DateTime _createTime;
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

        /// <summary>
        /// 获取令牌创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return this._createTime; }
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
        internal AccessToken(String tokenID, String tokenSecret, String userID, Byte userType, Int32 expiresIn)
            : this(tokenID, tokenSecret, userID, userType, expiresIn, DateTime.Now) { }

        /// <summary>
        /// 初始化新的访问令牌实体
        /// </summary>
        /// <param name="tokenID">令牌ID</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userType">用户类型</param>
        /// <param name="expiresIn">令牌超时时间</param>
        /// <param name="createTime">令牌创建时间</param>
        private AccessToken(String tokenID, String tokenSecret, String userID, Byte userType, Int32 expiresIn, DateTime createTime)
        {
            this._tokenID = tokenID;
            this._tokenSecret = tokenSecret;
            this._userID = userID;
            this._userType = (UserType)UserType;
            this._expiresIn = expiresIn;
            this._createTime = createTime;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取存储凭证
        /// </summary>
        /// <returns>访问令牌存储凭证</returns>
        public String ToStorageVoucher()
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}|{5}", 
                this._tokenID, this._tokenSecret, this._userID,
                ((Byte)this._userType).ToString(), this._expiresIn.ToString(), this._createTime.ToString(AccessToken.DateTimeStringFormat));
        }
        #endregion

        #region 内部方法
        /// <summary>
        /// 刷新访问令牌
        /// </summary>
        /// <param name="expiresIn">令牌超时时间</param>
        /// <param name="createTime">令牌创建时间</param>
        internal void RefreshToken(Int32 expiresIn, DateTime createTime)
        {
            this._expiresIn = expiresIn;
            this._createTime = createTime;
        }
        #endregion

        #region 静态方法
        /// <summary>
        /// 从存储凭证中创建访问令牌
        /// </summary>
        /// <param name="voucher">存储凭证</param>
        /// <returns>访问令牌</returns>
        internal static AccessToken CreateFromStorageVoucher(String voucher)
        {
            if (String.IsNullOrEmpty(voucher))
            {
                return null;
            }

            String[] items = voucher.Split('|');

            if (items.Length != 6)
            {
                return null;
            }

            String tokenID = items[0];
            String tokenSecret = items[1];
            String userID = items[2];
            Byte userType;
            Int32 expiresIn;
            DateTime createTime;

            if (!Byte.TryParse(items[3], out userType))
            {
                return null;
            }

            if (!Int32.TryParse(items[4], out expiresIn))
            {
                return null;
            }

            if (!DateTime.TryParseExact(items[5], DateTimeStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out createTime))
            {
                return null;
            }

            AccessToken accessToken = new AccessToken(tokenID, tokenSecret, userID, userType, expiresIn, createTime);

            return accessToken;
        }
        #endregion
    }
}