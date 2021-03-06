﻿using System;

using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 客户端接口
    /// </summary>
    public interface IClient
    {
        #region 属性
        /// <summary>
        /// 获取或设置OAuth根Url
        /// </summary>
        String OAuthBaseUrl { get; set; }

        /// <summary>
        /// 获取或设置OAuth请求令牌请求地址
        /// </summary>
        String OAuthRequestTokenUrl { get; }

        /// <summary>
        /// 获取或设置OAuth认证地址
        /// </summary>
        String OAuthAuthorizeUrl { get; }

        /// <summary>
        /// 获取或设置OAuth访问令牌请求地址
        /// </summary>
        String OAuthAccessTokenUrl { get; }

        /// <summary>
        /// 获取或设置OAuth服务请求根地址
        /// </summary>
        String RestRootUrl { get; }

        /// <summary>
        /// 获取OAuth默认回调地址
        /// </summary>
        String DefaultCallbackUrl { get; }

        /// <summary>
        /// 获取当前客户端Key
        /// </summary>
        String ConsumerKey { get; }

        /// <summary>
        /// 获取当前客户端密钥
        /// </summary>
        String ConsumerSecret { get; }

        /// <summary>
        /// 获取当前访问令牌
        /// </summary>
        AccessToken AccessToken { get; }
        #endregion

        #region 访问令牌相关
        /// <summary>
        /// 从存储凭证中加载访问令牌
        /// </summary>
        /// <param name="voucher">存储凭证</param>
        void LoadAccessTokenFromVoucher(String voucher);

        /// <summary>
        /// 清除访问令牌
        /// </summary>
        void ClearAccessToken();
        #endregion

        #region 调用服务方法
        /// <summary>
        /// 异步调用服务方法（返回原始数据）
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数返回原始数据</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        void RequestRestMethodRawResultAsync(IRestMethod restMethod, Action<String> callback);

        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <param name="restMethod">服务方法</param>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        void RequestRestMethodAsync(IRestMethod restMethod);

        /// <summary>
        /// 异步调用服务方法
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="restMethod">服务方法</param>
        /// <param name="callback">回调函数返回实体数据</param>
        /// <exception cref="NullReferenceException">Json反序列化器不能为空</exception>
        /// <exception cref="ArgumentNullException">服务方法不能为空</exception>
        void RequestRestMethodAsync<T>(IRestMethod<T> restMethod, Action<IRestResult<T>> callback);
        #endregion
    }
}