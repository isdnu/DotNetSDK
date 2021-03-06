﻿using System;
using System.Collections.Generic;

using SDNUMobile.SDK.Net;
using SDNUMobile.SDK.Utilities;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 抽象客户端
    /// </summary>
    public abstract class AbstractClient : IClient
    {
        #region 字段
        /// <summary>
        /// OAuth根Url
        /// </summary>
        private String _oauthBaseUrl;

        /// <summary>
        /// OAuth请求令牌请求地址
        /// </summary>
        private String _oauthRequestTokenUrl;

        /// <summary>
        /// OAuth认证地址
        /// </summary>
        private String _oauthAuthorizeUrl;

        /// <summary>
        /// OAuth访问令牌请求地址
        /// </summary>
        private String _oauthAccessTokenUrl;

        /// <summary>
        /// OAuth服务请求根地址
        /// </summary>
        private String _restRootUrl;

        /// <summary>
        /// OAuth服务请求根地址
        /// </summary>
        private String _defaultCallbackUrl;

        /// <summary>
        /// 客户端Key
        /// </summary>
        protected String _consumerKey;

        /// <summary>
        /// 客户端密钥
        /// </summary>
        protected String _consumerSecret;

        /// <summary>
        /// 访问令牌实体
        /// </summary>
        protected AccessToken _accessToken;

        /// <summary>
        /// Json反序列化器
        /// </summary>
        protected IJsonDeserializer _jsonDeserializer;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置OAuth根Url
        /// </summary>
        public String OAuthBaseUrl
        {
            get { return this._oauthBaseUrl; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this.SetBaseUrl(value);
            }
        }

        /// <summary>
        /// 获取OAuth请求令牌请求地址
        /// </summary>
        public String OAuthRequestTokenUrl
        {
            get { return this._oauthRequestTokenUrl; }
        }

        /// <summary>
        /// 获取OAuth认证地址
        /// </summary>
        public String OAuthAuthorizeUrl
        {
            get { return this._oauthAuthorizeUrl; }
        }

        /// <summary>
        /// 获取OAuth访问令牌请求地址
        /// </summary>
        public String OAuthAccessTokenUrl
        {
            get { return this._oauthAccessTokenUrl; }
        }

        /// <summary>
        /// 获取OAuth服务请求根地址
        /// </summary>
        public String RestRootUrl
        {
            get { return this._restRootUrl; }
        }

        /// <summary>
        /// 获取OAuth默认回调地址
        /// </summary>
        public String DefaultCallbackUrl
        {
            get { return this._defaultCallbackUrl; }
        }

        /// <summary>
        /// 获取当前客户端Key
        /// </summary>
        public String ConsumerKey
        {
            get { return this._consumerKey; }
        }

        /// <summary>
        /// 获取当前客户端密钥
        /// </summary>
        public String ConsumerSecret
        {
            get { return this._consumerSecret; }
        }

        /// <summary>
        /// 获取当前访问令牌
        /// </summary>
        public AccessToken AccessToken
        {
            get { return this._accessToken; }
        }

        /// <summary>
        /// 获取或设置Json反序列化器
        /// </summary>
        public IJsonDeserializer JsonDeserializer
        {
            get { return this._jsonDeserializer; }
            set { this._jsonDeserializer = value; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的抽象客户端
        /// </summary>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        internal AbstractClient(String consumerKey, String consumerSecret)
            : this(null, consumerKey, consumerSecret, null) { }

        /// <summary>
        /// 初始化新的抽象客户端
        /// </summary>
        /// <param name="jsonDeserializer">Json反序列化器</param>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        internal AbstractClient(IJsonDeserializer jsonDeserializer, String consumerKey, String consumerSecret)
            : this(jsonDeserializer, consumerKey, consumerSecret, null) { }

        /// <summary>
        /// 初始化新的抽象客户端
        /// </summary>
        /// <param name="jsonDeserializer">Json反序列化器</param>
        /// <param name="consumerKey">客户端Key</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="voucher">访问令牌存储凭证</param>
        internal AbstractClient(IJsonDeserializer jsonDeserializer, String consumerKey, String consumerSecret, String voucher)
        {
            this.SetBaseUrl(Constants.DefaultBaseUrl);

            this._jsonDeserializer = jsonDeserializer;
            this._consumerKey = consumerKey;
            this._consumerSecret = consumerSecret;
            this._accessToken = AccessToken.CreateFromStorageVoucher(voucher);
        }
        #endregion

        #region 访问令牌相关
        /// <summary>
        /// 从存储凭证中加载访问令牌
        /// </summary>
        /// <param name="voucher">存储凭证</param>
        public void LoadAccessTokenFromVoucher(String voucher)
        {
            this._accessToken = AccessToken.CreateFromStorageVoucher(voucher);
        }

        /// <summary>
        /// 清除访问令牌
        /// </summary>
        public void ClearAccessToken()
        {
            this._accessToken = null;
        }
        #endregion

        #region 调用服务方法
        /// <summary>
        /// 异步调用服务方法（返回原始数据）
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数返回原始数据</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void RequestRestMethodRawResultAsync(IRestMethod restMethod, Action<String> callback)
        {
            if (restMethod == null)
            {
                throw new ArgumentNullException("restMethod");
            }

            String url = String.Format("{0}/{1}", this.RestRootUrl, restMethod.MethodPath);

            List<RequestParameter> headers = new List<RequestParameter>();
            headers.Add(new RequestParameter(OAuthConstants.ConsumerKeyParameter, this._consumerKey));
            headers.Add(new RequestParameter(OAuthConstants.NonceParameter, this.GenerateNonce()));
            headers.Add(new RequestParameter(OAuthConstants.SignatureMethodParameter, OAuthConstants.SupportSignatureMethod));
            headers.Add(new RequestParameter(OAuthConstants.TimestampParameter, this.GetCurrentTimestamp()));

            if (this._accessToken != null)
            {
                headers.Add(new RequestParameter(OAuthConstants.TokenParameter, this._accessToken.TokenID));
            }
            
            headers.Add(new RequestParameter(OAuthConstants.VersionParameter, OAuthConstants.CurrentVersion));

            OAuthHttpClient.RequestRemoteContentAsync(restMethod.RequestMethod, url, 
                this._consumerSecret, (this._accessToken != null ? this._accessToken.TokenSecret : String.Empty),
                headers, restMethod.Parameters, callback);
        }

        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void RequestRestMethodAsync(IRestMethod restMethod)
        {
            this.RequestRestMethodRawResultAsync(restMethod, null);
        }

        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数返回实体数据</param>
        /// <exception cref="NullReferenceException">Json反序列化器不能为空</exception>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void RequestRestMethodAsync<T>(IRestMethod<T> restMethod, Action<IRestResult<T>> callback)
        {
            if (this._jsonDeserializer == null)
            {
                throw new NullReferenceException();
            }

            this.RequestRestMethodRawResultAsync(restMethod, content => 
            {
                if (callback != null)
                {
                    IRestResult<T> result = this.GetRestResultFromJson<T>(restMethod, content);

                    callback(result);
                }
            });
        }
        #endregion

        #region 保护方法
        /// <summary>
        /// 获取一个唯一值
        /// </summary>
        /// <returns>唯一值内容</returns>
        protected String GenerateNonce()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns>当前时间戳内容</returns>
        protected String GetCurrentTimestamp()
        {
            return UnixTimeConverter.ToUnixTime(DateTime.Now).ToString();
        }

        /// <summary>
        /// 从字符串中获取访问令牌实体
        /// </summary>
        /// <param name="content">字符串内容</param>
        /// <returns>访问令牌实体</returns>
        protected AccessToken GetAccessTokenFromString(String content)
        {
            if (String.IsNullOrEmpty(content) || !content.StartsWith(OAuthConstants.TokenParameter, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            Dictionary<String, String> dict = this.GetDictionaryFromString(content);

            if (!dict.ContainsKey(OAuthConstants.TokenParameter) ||
                !dict.ContainsKey(OAuthConstants.TokenSecretParameter) ||
                !dict.ContainsKey("user_id") || 
                !dict.ContainsKey("user_type") ||
                !dict.ContainsKey("expires_in"))
            {
                return null;
            }

            String tokenID = dict[OAuthConstants.TokenParameter];
            String tokenSecret = dict[OAuthConstants.TokenSecretParameter];
            String userID = dict["user_id"];
            Byte userType;
            Int32 expiresIn;

            if (!Byte.TryParse(dict["user_type"], out userType))
            {
                return null;
            }

            if (!Int32.TryParse(dict["expires_in"], out expiresIn))
            {
                return null;
            }

            AccessToken accessToken = new AccessToken(tokenID, tokenSecret, userID, userType, expiresIn);

            return accessToken;
        }

        /// <summary>
        /// 从字符串中获取OAuth错误实体
        /// </summary>
        /// <param name="content">字符串内容</param>
        /// <returns>OAuth错误实体</returns>
        protected OAuthError GetOAuthErrorFromString(String content)
        {
            if (String.IsNullOrEmpty(content) || !content.StartsWith("error_code=", StringComparison.OrdinalIgnoreCase))
            {
                return OAuthError.GetUnknownError();
            }

            Dictionary<String, String> dict = this.GetDictionaryFromString(content);

            if (!dict.ContainsKey("error_code") || !dict.ContainsKey("error_type") || !dict.ContainsKey("error_description"))
            {
                return OAuthError.GetUnknownError();
            }
            
            Int32 errorCode;
            String errorType = dict["error_type"];
            String errorDescription = dict["error_description"];

            if (!Int32.TryParse(dict["error_code"], out errorCode))
            {
                return OAuthError.GetUnknownError();
            }

            OAuthError error = new OAuthError(errorCode, errorType, errorDescription);

            return error;
        }

        /// <summary>
        /// 从Json中获取服务结果
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="method">服务方法</param>
        /// <param name="content">Json内容</param>
        /// <returns>服务结果</returns>
        protected IRestResult<T> GetRestResultFromJson<T>(IRestMethod method, String content)
        {
            if (String.IsNullOrEmpty(content))
            {
                return new RestResult<T>(method, default(T));
            }

            if (content.IndexOf("errorCode") >= 0)
            {
                OAuthError error = this._jsonDeserializer.DeserializeJson<OAuthError>(content);
                return new RestResult<T>(method, error);
            }

            T entity = this._jsonDeserializer.DeserializeJson<T>(content);
            return new RestResult<T>(method, entity);
        }

        /// <summary>
        /// 从字符串中获取字典
        /// </summary>
        /// <param name="content">字符串内容</param>
        /// <returns>获取到的字典</returns>
        protected Dictionary<String, String> GetDictionaryFromString(String content)
        {
            Dictionary<String, String> dict = new Dictionary<String, String>();

            String[] items = content.Split('&');

            for (Int32 i = 0; i < items.Length; i++)
            {
                String[] pair = items[i].Split('=');

                if (pair.Length != 2)
                {
                    continue;
                }

                dict[pair[0]] = HttpUtility.UrlDecode(pair[1]);
            }

            return dict;
        }
        #endregion

        #region 私有方法
        private void SetBaseUrl(String baseUrl)
        {
            if (baseUrl[baseUrl.Length - 1] != '/')
            {
                baseUrl = baseUrl + '/';
            }

            this._oauthBaseUrl = baseUrl;
            this._oauthRequestTokenUrl = String.Format("{0}{1}", this._oauthBaseUrl, Constants.OAuthRequestTokenUri);
            this._oauthAuthorizeUrl = String.Format("{0}{1}", this._oauthBaseUrl, Constants.OAuthAuthorizeUri);
            this._oauthAccessTokenUrl = String.Format("{0}{1}", this._oauthBaseUrl, Constants.OAuthAccessTokenUri);
            this._restRootUrl = String.Format("{0}{1}", this._oauthBaseUrl, Constants.RestRootUri);
            this._defaultCallbackUrl = String.Format("{0}{1}", this._oauthBaseUrl, Constants.DefaultCallbackUri);
        }
        #endregion
    }
}