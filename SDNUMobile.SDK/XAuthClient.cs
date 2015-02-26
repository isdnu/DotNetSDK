using System;
using System.Collections.Generic;

using SDNUMobile.SDK.Net;
using SDNUMobile.SDK.Utilities;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// xAuth认证客户端
    /// </summary>
    public sealed class XAuthClient : AbstractClient
    {
        #region 构造方法
        /// <summary>
        /// 初始化新的xAuth认证客户端
        /// </summary>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        public XAuthClient(String consumerKey, String consumerSecret)
            : base(consumerKey, consumerSecret) { }

        /// <summary>
        /// 初始化新的xAuth认证客户端
        /// </summary>
        /// <param name="jsonDeserializer">Json反序列化器</param>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        public XAuthClient(IJsonDeserializer jsonDeserializer, String consumerKey, String consumerSecret)
            : base(jsonDeserializer, consumerKey, consumerSecret) { }

        /// <summary>
        /// 初始化新的xAuth认证客户端
        /// </summary>
        /// <param name="jsonDeserializer">Json反序列化器</param>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="voucher">访问令牌存储凭证</param>
        public XAuthClient(IJsonDeserializer jsonDeserializer, String consumerKey, String consumerSecret, String voucher)
            : base(jsonDeserializer, consumerKey, consumerSecret, voucher) { }
        #endregion

        #region 获取访问令牌
        /// <summary>
        /// 异步获取访问令牌（返回原始数据）
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <param name="callback">回调函数返回原始数据</param>
        /// <exception cref="ArgumentNullException">用户名密码不能为空</exception>
        public void RequestAccessTokenRawResultAsync(String userName, String passWord, Action<String> callback)
        {
            if (String.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }

            if (String.IsNullOrEmpty(passWord))
            {
                throw new ArgumentNullException("passWord");
            }

            String url = this.OAuthAccessTokenUrl;

            List<RequestParameter> headers = new List<RequestParameter>();
            headers.Add(new RequestParameter(OAuthConstants.ConsumerKeyParameter, this._consumerKey));
            headers.Add(new RequestParameter(OAuthConstants.NonceParameter, this.GenerateNonce()));
            headers.Add(new RequestParameter(OAuthConstants.SignatureMethodParameter, OAuthConstants.SupportSignatureMethod));
            headers.Add(new RequestParameter(OAuthConstants.TimestampParameter, this.GetCurrentTimestamp()));
            headers.Add(new RequestParameter(OAuthConstants.VersionParameter, OAuthConstants.CurrentVersion));
            headers.Add(new RequestParameter(OAuthConstants.AuthModeParameter, OAuthConstants.SupportXAuthMode));
            headers.Add(new RequestParameter(OAuthConstants.AuthPasswordParameter, passWord));
            headers.Add(new RequestParameter(OAuthConstants.AuthUsernameParameter, userName));

            OAuthHttpClient.PostRemoteContentAsync(url, this._consumerSecret, String.Empty, headers, content =>
            {
                this._accessToken = this.GetAccessTokenFromString(content);

                if (callback != null)
                {
                    callback(content);
                }
            });
        }

        /// <summary>
        /// 异步获取访问令牌
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <exception cref="ArgumentNullException">用户名密码不能为空</exception>
        public void RequestAccessTokenAsync(String userName, String passWord)
        {
            this.RequestAccessTokenRawResultAsync(userName, passWord, null);
        }

        /// <summary>
        /// 异步获取访问令牌
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <param name="callback">回调函数返回实体数据</param>
        /// <exception cref="ArgumentNullException">用户名密码不能为空</exception>
        public void RequestAccessTokenAsync(String userName, String passWord, Action<TokenResult> callback)
        {
            this.RequestAccessTokenRawResultAsync(userName, passWord, content =>
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
            });
        }
        #endregion
    }
}