using System;
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
        /// OAuth令牌刷新请求地址
        /// </summary>
        private String _oauthRefreshTokenUrl;

        /// <summary>
        /// OAuth服务请求根地址
        /// </summary>
        private String _restRootUrl;

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
        /// 获取或设置OAuth请求令牌请求地址
        /// </summary>
        /// <exception cref="ArgumentNullException">OAuth请求令牌请求地址不能为空</exception>
        public String OAuthRequestTokenUrl
        {
            get { return this._oauthRequestTokenUrl; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this._oauthRequestTokenUrl = value; 
            }
        }

        /// <summary>
        /// 获取或设置OAuth认证地址
        /// </summary>
        /// <exception cref="ArgumentNullException">OAuth认证地址地址不能为空</exception>
        public String OAuthAuthorizeUrl
        {
            get { return this._oauthAuthorizeUrl; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this._oauthAuthorizeUrl = value;
            }
        }

        /// <summary>
        /// 获取或设置OAuth访问令牌请求地址
        /// </summary>
        /// <exception cref="ArgumentNullException">OAuth访问令牌请求地址不能为空</exception>
        public String OAuthAccessTokenUrl
        {
            get { return this._oauthAccessTokenUrl; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this._oauthAccessTokenUrl = value;
            }
        }

        /// <summary>
        /// 获取或设置OAuth令牌刷新请求地址
        /// </summary>
        /// <exception cref="ArgumentNullException">OAuth令牌刷新请求地址不能为空</exception>
        public String OAuthRefreshTokenUrl
        {
            get { return this._oauthRefreshTokenUrl; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this._oauthRefreshTokenUrl = value;
            }
        }

        /// <summary>
        /// 获取或设置OAuth服务请求根地址
        /// </summary>
        /// <exception cref="ArgumentNullException">OAuth服务请求根地址不能为空</exception>
        public String RestRootUrl
        {
            get { return this._restRootUrl; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                this._restRootUrl = value;
            }
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
            this._oauthRequestTokenUrl = Constants.OAuthRequestTokenUrl;
            this._oauthAuthorizeUrl = Constants.OAuthAuthorizeUrl;
            this._oauthAccessTokenUrl = Constants.OAuthAccessTokenUrl;
            this._oauthRefreshTokenUrl = Constants.OAuthRefreshTokenUrl;
            this._restRootUrl = Constants.RestRootUrl;

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

        #region 刷新访问令牌
        /// <summary>
        /// 异步刷新访问令牌
        /// </summary>
        /// <param name="callback">回调函数返回原始数据</param>
        /// <exception cref="NullReferenceException">访问令牌不能为空</exception>
        public void RefreshAccessTokenAsync(Action<String> callback)
        {
            if (this._accessToken == null)
            {
                throw new NullReferenceException();
            }

            String url = this.OAuthRefreshTokenUrl;

            List<RequestParameter> headers = new List<RequestParameter>();
            headers.Add(new RequestParameter(OAuthConstants.ConsumerKeyParameter, this._consumerKey));
            headers.Add(new RequestParameter(OAuthConstants.NonceParameter, Guid.NewGuid().ToString("N")));
            headers.Add(new RequestParameter(OAuthConstants.SignatureMethodParameter, OAuthConstants.SupportSignatureMethod));
            headers.Add(new RequestParameter(OAuthConstants.TimestampParameter, UnixTimeConverter.ToUnixTime(DateTime.Now).ToString()));
            headers.Add(new RequestParameter(OAuthConstants.TokenParameter, this._accessToken.TokenID));
            headers.Add(new RequestParameter(OAuthConstants.VersionParameter, OAuthConstants.CurrentVersion));

            OAuthHttpRequest.PostRemoteContentAsync(url, this._consumerSecret, this._accessToken.TokenSecret, headers, content =>
            {
                AccessToken refreshedToken = this.GetAccessTokenFromString(content);
                    
                if (refreshedToken != null)
                {
                    this._accessToken.RefreshToken(refreshedToken.ExpiresIn, refreshedToken.CreateTime);
                }

                if (callback != null)
                {
                    callback(content);
                }
            });
        }

        /// <summary>
        /// 异步刷新访问令牌
        /// </summary>
        /// <exception cref="NullReferenceException">访问令牌不能为空</exception>
        public void RefreshAccessTokenAsync()
        {
            this.RefreshAccessTokenAsync((String content) => { });
        }

        /// <summary>
        /// 异步刷新访问令牌
        /// </summary>
        /// <param name="callback">回调函数返回实体数据</param>
        /// <exception cref="NullReferenceException">Json反序列化器不能为空</exception>
        /// <exception cref="NullReferenceException">访问令牌不能为空</exception>
        public void RefreshAccessTokenAsync(Action<TokenResult> callback)
        {
            if (this._jsonDeserializer == null)
            {
                throw new NullReferenceException();
            }

            this.RefreshAccessTokenAsync(content =>
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

        #region 调用服务方法
        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <param name="method">请求方式</param>
        /// <param name="callback">回调函数返回原始数据</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void RequestRestMethodAsync(IRestMethod restMethod, RequestMethod method, Action<String> callback)
        {
            if (restMethod == null)
            {
                throw new ArgumentNullException("restMethod");
            }

            String url = String.Format("{0}/{1}", this.RestRootUrl, restMethod.MethodPath);

            List<RequestParameter> headers = new List<RequestParameter>();
            headers.Add(new RequestParameter(OAuthConstants.ConsumerKeyParameter, this._consumerKey));
            headers.Add(new RequestParameter(OAuthConstants.NonceParameter, Guid.NewGuid().ToString("N")));
            headers.Add(new RequestParameter(OAuthConstants.SignatureMethodParameter, OAuthConstants.SupportSignatureMethod));
            headers.Add(new RequestParameter(OAuthConstants.TimestampParameter, UnixTimeConverter.ToUnixTime(DateTime.Now).ToString()));

            if (this._accessToken != null)
            {
                headers.Add(new RequestParameter(OAuthConstants.TokenParameter, this._accessToken.TokenID));
            }
            
            headers.Add(new RequestParameter(OAuthConstants.VersionParameter, OAuthConstants.CurrentVersion));

            OAuthHttpRequest.RequestRemoteContentAsync(method, url, 
                this._consumerSecret, (this._accessToken != null ? this._accessToken.TokenSecret : String.Empty),
                headers, restMethod.Parameters, callback);
        }

        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <param name="method">请求方式</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void RequestRestMethodAsync(IRestMethod restMethod, RequestMethod method)
        {
            this.RequestRestMethodAsync(restMethod, method, null);
        }

        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="restMethod">服务方法</param>
        /// <param name="method">请求方式</param>
        /// <param name="callback">回调函数返回实体数据</param>
        /// <exception cref="NullReferenceException">Json反序列化器不能为空</exception>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void RequestRestMethodAsync<T>(IRestMethod<T> restMethod, RequestMethod method, Action<IRestResult<T>> callback)
        {
            if (this._jsonDeserializer == null)
            {
                throw new NullReferenceException();
            }

            this.RequestRestMethodAsync(restMethod, method, content => 
            {
                if (callback != null)
                {
                    IRestResult<T> result = this.GetRestResultFromJson<T>(restMethod, content);

                    callback(result);
                }
            });
        }

        /// <summary>
        /// 异步Get调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数返回原始数据</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void GetRestMethodAsync(IRestMethod restMethod, Action<String> callback)
        {
            this.RequestRestMethodAsync(restMethod, RequestMethod.Get, callback);
        }

        /// <summary>
        /// 异步Get调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void GetRestMethodAsync(IRestMethod restMethod)
        {
            this.RequestRestMethodAsync(restMethod, RequestMethod.Get);
        }

        /// <summary>
        /// 异步Get调用服务方法
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数返回实体数据</param>
        /// <exception cref="NullReferenceException">Json反序列化器不能为空</exception>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void GetRestMethodAsync<T>(IRestMethod<T> restMethod, Action<IRestResult<T>> callback)
        {
            this.RequestRestMethodAsync<T>(restMethod, RequestMethod.Get, callback);
        }

        /// <summary>
        /// 异步Post调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数返回原始数据</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void PostRestMethodAsync(IRestMethod restMethod, Action<String> callback)
        {
            this.RequestRestMethodAsync(restMethod, RequestMethod.Post, callback);
        }

        /// <summary>
        /// 异步Post调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void PostRestMethodAsync(IRestMethod restMethod)
        {
            this.RequestRestMethodAsync(restMethod, RequestMethod.Post);
        }

        /// <summary>
        /// 异步Post调用服务方法
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数返回实体数据</param>
        /// <exception cref="NullReferenceException">Json反序列化器不能为空</exception>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void PostRestMethodAsync<T>(IRestMethod<T> restMethod, Action<IRestResult<T>> callback)
        {
            this.RequestRestMethodAsync<T>(restMethod, RequestMethod.Post, callback);
        }
        #endregion

        #region 保护方法
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
                return null;
            }

            Dictionary<String, String> dict = this.GetDictionaryFromString(content);

            if (!dict.ContainsKey("error_code") || !dict.ContainsKey("error_type") || !dict.ContainsKey("error_description"))
            {
                return null;
            }
            
            Int32 errorCode;
            String errorType = dict["error_type"];
            String errorDescription = dict["error_description"];

            if (!Int32.TryParse(dict["error_code"], out errorCode))
            {
                return null;
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
    }
}