using System;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// OAuth常量类
    /// </summary>
    public static class OAuthConstants
    {
        /// <summary>
        /// 获取OAuth验证参数头
        /// </summary>
        public const String AuthorizationOAuthHeader = "OAuth ";

        /// <summary>
        /// 获取应用Key参数名
        /// </summary>
        public const String ConsumerKeyParameter = "oauth_consumer_key";

        /// <summary>
        /// 获取单次值参数名
        /// </summary>
        public const String NonceParameter = "oauth_nonce";

        /// <summary>
        /// 获取回调地址参数名
        /// </summary>
        public const String CallbackParameter = "oauth_callback";

        /// <summary>
        /// 获取验证码参数名
        /// </summary>
        public const String VerifierParameter = "oauth_verifier";

        /// <summary>
        /// 获取签名方法参数名
        /// </summary>
        public const String SignatureMethodParameter = "oauth_signature_method";

        /// <summary>
        /// 获取签名内容参数名
        /// </summary>
        public const String SignatureParameter = "oauth_signature";

        /// <summary>
        /// 获取时间戳参数名
        /// </summary>
        public const String TimestampParameter = "oauth_timestamp";

        /// <summary>
        /// 获取版本参数名
        /// </summary>
        public const String VersionParameter = "oauth_version";

        /// <summary>
        /// 获取令牌内容参数名
        /// </summary>
        public const String TokenParameter = "oauth_token";

        /// <summary>
        /// 获取令牌密钥参数名
        /// </summary>
        public const String TokenSecretParameter = "oauth_token_secret";

        /// <summary>
        /// 获取XAuth认证方式参数名
        /// </summary>
        public const String AuthModeParameter = "x_auth_mode";

        /// <summary>
        /// 获取XAuth认证用户密码参数名
        /// </summary>
        public const String AuthPasswordParameter = "x_auth_password";

        /// <summary>
        /// 获取XAuth认证用户名参数名
        /// </summary>
        public const String AuthUsernameParameter = "x_auth_username";

        /// <summary>
        /// 获取支持的XAuth认证方式
        /// </summary>
        public const String SupportXAuthMode = "client_auth";
    }
}