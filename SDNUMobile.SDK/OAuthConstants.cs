using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// OAuth常量类
    /// </summary>
    internal static class OAuthConstants
    {
        /// <summary>
        /// 获取OAuth验证参数头
        /// </summary>
        internal const String AuthorizationOAuthHeader = "OAuth ";

        #region 参数名
        /// <summary>
        /// 获取应用Key参数名
        /// </summary>
        internal const String ConsumerKeyParameter = "oauth_consumer_key";

        /// <summary>
        /// 获取单次值参数名
        /// </summary>
        internal const String NonceParameter = "oauth_nonce";

        /// <summary>
        /// 获取回调地址参数名
        /// </summary>
        internal const String CallbackParameter = "oauth_callback";

        /// <summary>
        /// 获取验证码参数名
        /// </summary>
        internal const String VerifierParameter = "oauth_verifier";

        /// <summary>
        /// 获取签名方法参数名
        /// </summary>
        internal const String SignatureMethodParameter = "oauth_signature_method";

        /// <summary>
        /// 获取签名内容参数名
        /// </summary>
        internal const String SignatureParameter = "oauth_signature";

        /// <summary>
        /// 获取时间戳参数名
        /// </summary>
        internal const String TimestampParameter = "oauth_timestamp";

        /// <summary>
        /// 获取版本参数名
        /// </summary>
        internal const String VersionParameter = "oauth_version";

        /// <summary>
        /// 获取令牌内容参数名
        /// </summary>
        internal const String TokenParameter = "oauth_token";

        /// <summary>
        /// 获取令牌密钥参数名
        /// </summary>
        internal const String TokenSecretParameter = "oauth_token_secret";

        /// <summary>
        /// 获取令牌回调地址验证状态参数名
        /// </summary>
        internal const String TokenCallbackConfirmed = "oauth_callback_confirmed";

        /// <summary>
        /// 获取XAuth认证方式参数名
        /// </summary>
        internal const String AuthModeParameter = "x_auth_mode";

        /// <summary>
        /// 获取XAuth认证用户密码参数名
        /// </summary>
        internal const String AuthPasswordParameter = "x_auth_password";

        /// <summary>
        /// 获取XAuth认证用户名参数名
        /// </summary>
        internal const String AuthUsernameParameter = "x_auth_username";
        #endregion

        #region 参数内容
        /// <summary>
        /// 获取支持的签名方法
        /// </summary>
        internal const String SupportSignatureMethod = "HMAC-SHA1";

        /// <summary>
        /// 获取支持的XAuth认证方式
        /// </summary>
        internal const String SupportXAuthMode = "client_auth";

        /// <summary>
        /// 获取当前使用的OAuth的版本
        /// </summary>
        internal const String CurrentVersion = "1.0";
        #endregion
    }
}