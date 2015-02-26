using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 常量类
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// 获取OAuth根地址
        /// </summary>
        internal const String DefaultBaseUrl = "http://i.sdnu.edu.cn/oauth/";

        /// <summary>
        /// 获取OAuth请求令牌请求地址
        /// </summary>
        internal const String OAuthRequestTokenUri = "request_token";

        /// <summary>
        /// 获取OAuth认证地址
        /// </summary>
        internal const String OAuthAuthorizeUri = "authorize";

        /// <summary>
        /// 获取OAuth访问令牌请求地址
        /// </summary>
        internal const String OAuthAccessTokenUri = "access_token";

        /// <summary>
        /// 获取OAuth服务请求根地址
        /// </summary>
        internal const String RestRootUri = "rest";

        /// <summary>
        /// 获取OAuth默认回调地址
        /// </summary>
        internal const String DefaultCallbackUri = "index.html";
    }
}