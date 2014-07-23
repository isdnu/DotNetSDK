using System;

namespace SDNUMobile.SDK.Entity.User
{
    /// <summary>
    /// 用户信息实体
    /// </summary>
    public class UserInfo
    {
        #region 字段
        private String _userID;
        private UserType _userType;
        private String _bindCellphone;
        private String _bindEmail;
        #endregion

        #region 属性
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
        public UserType UserType
        {
            get { return this._userType; }
            set { this._userType = value; }
        }

        /// <summary>
        /// 获取或设置绑定手机号码
        /// </summary>
        public String BindCellphone
        {
            get { return this._bindCellphone; }
            set { this._bindCellphone = value; }
        }

        /// <summary>
        /// 获取或设置绑定电子邮箱
        /// </summary>
        public String BindEmail
        {
            get { return this._bindEmail; }
            set { this._bindEmail = value; }
        }
        #endregion
    }
}