using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 常量类
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// 获取OAuth请求令牌请求地址
        /// </summary>
        public const String OAuthRequestTokenUrl = @"http://i.sdnu.edu.cn/oauth/request_token";

        /// <summary>
        /// 获取OAuth认证地址
        /// </summary>
        public const String OAuthAuthorizeUrl = @"http://i.sdnu.edu.cn/oauth/authorize";

        /// <summary>
        /// 获取OAuth访问令牌请求地址
        /// </summary>
        public const String OAuthAccessTokenUrl = @"http://i.sdnu.edu.cn/oauth/access_token";

        /// <summary>
        /// 获取OAuth令牌刷新请求地址
        /// </summary>
        public const String OAuthRefreshTokenUrl = @"http://i.sdnu.edu.cn/oauth/refresh_token";

        /// <summary>
        /// 获取OAuth服务请求根地址
        /// </summary>
        public const String RestRootUrl = @"http://i.sdnu.edu.cn/oauth/rest";
    }
}