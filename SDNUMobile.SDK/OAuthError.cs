using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// OAuth错误代码
    /// </summary>
    public enum OAuthErrorCode
    {
        /// <summary>
        /// 协议版本不支持
        /// </summary>
        ProtocolVersionNotSupported = 10001,

        /// <summary>
        /// 时间戳无效
        /// </summary>
        TimestampInvalid = 10002,

        /// <summary>
        /// 单次值无效
        /// </summary>
        NonceInvalid = 10003,

        /// <summary>
        /// 单次值重复
        /// </summary>
        NonceRepeated = 10004,

        /// <summary>
        /// 签名方法不支持
        /// </summary>
        SignatureMethodNotSupported = 10005,

        /// <summary>
        /// 签名无效
        /// </summary>
        SignatureInvalid = 10006,

        /// <summary>
        /// 回调地址为空
        /// </summary>
        CallbackUrlEmpty = 10007,

        /// <summary>
        /// Http方法错误
        /// </summary>
        HttpMethodInvalid = 10008,

        /// <summary>
        /// 应用Key无效
        /// </summary>
        ConsumerKeyInvalid = 10101,

        /// <summary>
        /// 该应用不允许用户登陆（只支持公共内容）
        /// </summary>
        ConsumerNotAllowUserAuth = 10102,

        /// <summary>
        /// 该应用无指定权限
        /// </summary>
        ConsumerNoPermission = 10103,

        /// <summary>
        /// 该应用暂未启用
        /// </summary>
        ConsumerNotEnabled = 10104,

        /// <summary>
        /// 该应用无XAuth认证权限
        /// </summary>
        ConsumerNoXAuthPermission = 10201,

        /// <summary>
        /// 请求令牌所有者非法
        /// </summary>
        RequestTokenOwnerInvalid = 11001,

        /// <summary>
        /// 请求令牌为空
        /// </summary>
        RequestTokenEmpty = 11002,

        /// <summary>
        /// 请求令牌非法
        /// </summary>
        RequestTokenInvalid = 11003,

        /// <summary>
        /// 请求令牌未被授权
        /// </summary>
        RequestTokenNotAuthorized = 11004,

        /// <summary>
        /// 请求令牌验证码为空
        /// </summary>
        RequestTokenVerifierEmpty = 11005,

        /// <summary>
        /// 请求令牌验证码无效
        /// </summary>
        RequestTokenVerifierInvalid = 11006,

        /// <summary>
        /// 用户未授权该应用
        /// </summary>
        UserNotAuthorized = 11011,

        /// <summary>
        /// 访问令牌所有者非法
        /// </summary>
        AccessTokenOwnerInvalid = 11101,

        /// <summary>
        /// 访问令牌为空
        /// </summary>
        AccessTokenEmpty = 11102,

        /// <summary>
        /// 访问令牌非法
        /// </summary>
        AccessTokenInvalid = 11103,

        /// <summary>
        /// 用户未授权该权限
        /// </summary>
        PermissionNotAuthorized = 11104,

        /// <summary>
        /// XAuth认证模式不支持
        /// </summary>
        AuthModeNotSupported = 12001,

        /// <summary>
        /// XAuth认证用户名为空
        /// </summary>
        UsernameEmpty = 12101,

        /// <summary>
        /// XAuth认证密码为空
        /// </summary>
        PasswordEmpty = 12102,
        
        /// <summary>
        /// XAuth认证用户名密码错误
        /// </summary>
        UsernameOrPasswordWrong = 12103,

        /// <summary>
        /// 用户未绑定邮箱
        /// </summary>
        UserNotSetEmail = 12104,

        /// <summary>
        /// 服务方法无效
        /// </summary>
        RestMethodInvalid = 20001,

        /// <summary>
        /// 服务特定错误（请参考错误描述）
        /// </summary>
        RestMethodError = 29999
    }

    /// <summary>
    /// OAuth错误信息
    /// </summary>
    public class OAuthError
    {
        #region 字段
        private OAuthErrorCode _errorCode;
        private String _errorType;
        private String _errorDescription;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置OAuth错误代码
        /// </summary>
        public OAuthErrorCode ErrorCode
        {
            get { return this._errorCode; }
            set { this._errorCode = value; }
        }

        /// <summary>
        /// 获取或设置OAuth错误类型
        /// </summary>
        public String ErrorType
        {
            get { return this._errorType; }
            set { this._errorType = value; }
        }

        /// <summary>
        /// 获取或设置OAuth错误描述
        /// </summary>
        public String ErrorDescription
        {
            get { return this._errorDescription; }
            set { this._errorDescription = value; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化OAuth错误信息
        /// </summary>
        public OAuthError() { }
        
        /// <summary>
        /// 初始化OAuth错误信息
        /// </summary>
        /// <param name="code">OAuth错误代码</param>
        /// <param name="type">OAuth错误类型</param>
        /// <param name="description">OAuth错误描述</param>
        internal OAuthError(Int32 code, String type, String description)
        {
            this._errorCode = (OAuthErrorCode)code;
            this._errorType = type;
            this._errorDescription = description;
        }
        #endregion
    }
}