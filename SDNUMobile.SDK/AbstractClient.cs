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
        private String _consumerKey;
        private String _consumerSecret;
        private AccessToken _accessToken;
        private IJsonDeserializer _jsonDeserializer;
        #endregion

        #region 属性
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
            this._jsonDeserializer = jsonDeserializer;
            this._consumerKey = consumerKey;
            this._consumerSecret = consumerSecret;
            this._accessToken = AccessToken.CreateFromStorageVoucher(voucher);
        }
        #endregion

        #region 方法
        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数</param>
        /// <exception cref="">Json反序列化器不能为空</exception>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        public void RequestRestMethodAsync(AbstractRestMethod restMethod, Action<RestResult> callback)
        {
            if (restMethod == null)
            {
                throw new ArgumentNullException("restMethod");
            }

            if (this._jsonDeserializer == null)
            {
                throw new NullReferenceException();
            }

            String url = String.Format("{0}/{1}", Constants.RestRootUrl, restMethod.MethodPath);

            List<RequestParameter> headers = new List<RequestParameter>();
            headers.Add(new RequestParameter(OAuthConstants.ConsumerKeyParameter, this._consumerKey));
            headers.Add(new RequestParameter(OAuthConstants.NonceParameter, Guid.NewGuid().ToString("N")));
            headers.Add(new RequestParameter(OAuthConstants.SignatureMethodParameter, OAuthConstants.SupportSignatureMethod));
            headers.Add(new RequestParameter(OAuthConstants.TimestampParameter, UnixTimeConverter.ToUnixTime(DateTime.Now).ToString()));
            headers.Add(new RequestParameter(OAuthConstants.TokenParameter, (this._accessToken != null ? this._accessToken.TokenID : String.Empty)));
            headers.Add(new RequestParameter(OAuthConstants.VersionParameter, OAuthConstants.CurrentVersion));

            OAuthHttpRequest.PostRemoteContentAsync(url, this._consumerSecret, (this._accessToken != null ? this._accessToken.TokenSecret : String.Empty),
                headers, restMethod.Parameters, new Action<String>((String content) => 
            {
                if (callback != null)
                {
                    RestResult result = this.GetRestResult(restMethod, content, restMethod.ResultEntityType);

                    callback(result);
                }
            }));
        }
        #endregion

        #region 私有方法
        private RestResult GetRestResult(AbstractRestMethod method, String content, Type type)
        {
            if (String.IsNullOrEmpty(content))
            {
                return new RestResult(method, null);
            }

            if (content.IndexOf("errorCode") >= 0)
            {
                OAuthError error = this._jsonDeserializer.DeserializeJson(content, typeof(OAuthError)) as OAuthError;
                return new RestResult(method, error);
            }

            Object entity = this._jsonDeserializer.DeserializeJson(content, type);
            return new RestResult(method, entity);
        }
        #endregion
    }
}