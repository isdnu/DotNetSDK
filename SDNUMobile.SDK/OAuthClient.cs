using System;
using System.Collections.Generic;

using SDNUMobile.SDK.Net;
using SDNUMobile.SDK.Utilities;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// OAuth1.0a认证客户端
    /// </summary>
    public sealed class OAuthClient : AbstractClient
    {
        #region 构造方法
        /// <summary>
        /// 初始化新的OAuth1.0a认证客户端
        /// </summary>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        public OAuthClient(String consumerKey, String consumerSecret)
            : base(consumerKey, consumerSecret) { }

        /// <summary>
        /// 初始化新的OAuth1.0a认证客户端
        /// </summary>
        /// <param name="jsonDeserializer">Json反序列化器</param>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        public OAuthClient(IJsonDeserializer jsonDeserializer, String consumerKey, String consumerSecret)
            : base(jsonDeserializer, consumerKey, consumerSecret) { }

        /// <summary>
        /// 初始化新的OAuth1.0a认证客户端
        /// </summary>
        /// <param name="jsonDeserializer">Json反序列化器</param>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="voucher">访问令牌存储凭证</param>
        public OAuthClient(IJsonDeserializer jsonDeserializer, String consumerKey, String consumerSecret, String voucher)
            : base(jsonDeserializer, consumerKey, consumerSecret, voucher) { }
        #endregion

        #region 方法
        /// <summary>
        /// 异步获取请求令牌
        /// </summary>
        /// <param name="callbackUrl">回调地址</param>
        /// <param name="callback">回调函数返回原始数据</param>
        public void RequestRequestTokenAsync(String callbackUrl, Action<String> callback)
        {
            String url = this.OAuthRequestTokenUrl;

            if (String.IsNullOrEmpty(callbackUrl))
            {
                callbackUrl = Constants.DefaultCallbackUrl;
            }

            List<RequestParameter> headers = new List<RequestParameter>();
            headers.Add(new RequestParameter(OAuthConstants.CallbackParameter, callbackUrl));
            headers.Add(new RequestParameter(OAuthConstants.ConsumerKeyParameter, this._consumerKey));
            headers.Add(new RequestParameter(OAuthConstants.NonceParameter, Guid.NewGuid().ToString("N")));
            headers.Add(new RequestParameter(OAuthConstants.SignatureMethodParameter, OAuthConstants.SupportSignatureMethod));
            headers.Add(new RequestParameter(OAuthConstants.TimestampParameter, UnixTimeConverter.ToUnixTime(DateTime.Now).ToString()));
            headers.Add(new RequestParameter(OAuthConstants.VersionParameter, OAuthConstants.CurrentVersion));

            OAuthHttpRequest.GetRemoteContentAsync(url, this._consumerSecret, String.Empty, headers, callback);
        }

        /// <summary>
        /// 异步获取请求令牌
        /// </summary>
        /// <param name="callbackUrl">回调地址</param>
        /// <param name="callback">回调函数返回错误实体（如果有）</param>
        public void RequestRequestTokenAsync(String callbackUrl, Action<TokenResult> callback)
        {
            this.RequestRequestTokenAsync(callbackUrl, new Action<String>((String content) =>
            {
                if (callback != null)
                {
                    RequestToken requestToken = this.GetRequestTokenFromString(content);
                    TokenResult result = null;

                    if (requestToken != null)
                    {
                        result = new TokenResult(requestToken);
                    }
                    else
                    {
                        OAuthError error = this.GetOAuthErrorFromString(content);
                        result = new TokenResult(error);
                    }

                    callback(result);
                }
            }));
        }
        
        /// <summary>
        /// 异步获取请求令牌
        /// </summary>
        /// <param name="callback">回调函数返回原始数据</param>
        public void RequestRequestTokenAsync(Action<String> callback)
        {
            this.RequestRequestTokenAsync(callback);
        }

        /// <summary>
        /// 异步获取请求令牌
        /// </summary>
        /// <param name="callback">回调函数返回错误实体（如果有）</param>
        public void RequestRequestTokenAsync(Action<TokenResult> callback)
        {
            this.RequestRequestTokenAsync(String.Empty, callback);
        }

        /// <summary>
        /// 异步获取访问令牌
        /// </summary>
        /// <param name="requestToken">请求令牌</param>
        /// <param name="verifier">令牌验证码</param>
        /// <param name="callback">回调函数返回原始数据</param>
        /// <exception cref="ArgumentNullException">请求令牌和令牌验证码不能为空</exception>
        public void RequestAccessTokenAsync(RequestToken requestToken, String verifier, Action<String> callback)
        {
            if (requestToken == null)
            {
                throw new ArgumentNullException("requestToken");
            }

            if (String.IsNullOrEmpty(verifier))
            {
                throw new ArgumentNullException("verifier");
            }

            String url = this.OAuthAccessTokenUrl;

            List<RequestParameter> headers = new List<RequestParameter>();
            headers.Add(new RequestParameter(OAuthConstants.ConsumerKeyParameter, this._consumerKey));
            headers.Add(new RequestParameter(OAuthConstants.NonceParameter, Guid.NewGuid().ToString("N")));
            headers.Add(new RequestParameter(OAuthConstants.SignatureMethodParameter, OAuthConstants.SupportSignatureMethod));
            headers.Add(new RequestParameter(OAuthConstants.TimestampParameter, UnixTimeConverter.ToUnixTime(DateTime.Now).ToString()));
            headers.Add(new RequestParameter(OAuthConstants.TokenParameter, requestToken.TokenID));
            headers.Add(new RequestParameter(OAuthConstants.VerifierParameter, verifier));
            headers.Add(new RequestParameter(OAuthConstants.VersionParameter, OAuthConstants.CurrentVersion));

            OAuthHttpRequest.GetRemoteContentAsync(url, this._consumerSecret, requestToken.TokenSecret, headers,
                new Action<String>((String content) =>
                {
                    this._accessToken = this.GetAccessTokenFromString(content);

                    if (callback != null)
                    {
                        callback(content);
                    }
                }));
        }

        /// <summary>
        /// 异步获取访问令牌
        /// </summary>
        /// <param name="requestToken">请求令牌</param>
        /// <param name="verifier">令牌验证码</param>
        /// <exception cref="ArgumentNullException">请求令牌和令牌验证码不能为空</exception>
        public void RequestAccessTokenAsync(RequestToken requestToken, String verifier)
        {
            this.RequestAccessTokenAsync(requestToken, verifier, new Action<String>((String content) => { }));
        }

        /// <summary>
        /// 异步获取访问令牌
        /// </summary>
        /// <param name="requestToken">请求令牌</param>
        /// <param name="verifier">令牌验证码</param>
        /// <param name="callback">回调函数返回错误实体（如果有）</param>
        /// <exception cref="ArgumentNullException">请求令牌和令牌验证码不能为空</exception>
        public void RequestAccessTokenAsync(RequestToken requestToken, String verifier, Action<TokenResult> callback)
        {
            this.RequestAccessTokenAsync(requestToken, verifier, new Action<String>((String content) =>
            {
                if (callback != null)
                {
                    OAuthError error = this.GetOAuthErrorFromString(content);
                    TokenResult result = null;

                    if (error == null)
                    {
                        result = new TokenResult(this._accessToken);
                    }
                    else
                    {
                        result = new TokenResult(error);
                    }

                    callback(result);
                }
            }));
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 从字符串中获取请求令牌实体
        /// </summary>
        /// <param name="content">字符串内容</param>
        /// <returns>请求令牌实体</returns>
        private RequestToken GetRequestTokenFromString(String content)
        {
            if (String.IsNullOrEmpty(content) || !content.StartsWith("oauth_token=", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            Dictionary<String, String> dict = this.GetDictionaryFromString(content);

            if (!dict.ContainsKey("oauth_token") || !dict.ContainsKey("oauth_token_secret") || !dict.ContainsKey("oauth_callback_confirmed") ||
                !String.Equals(dict["oauth_callback_confirmed"], "true", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            String tokenID = dict["oauth_token"];
            String tokenSecret = dict["oauth_token_secret"];

            RequestToken requestToken = new RequestToken(tokenID, tokenSecret);

            return requestToken;
        }
        #endregion
    }
}