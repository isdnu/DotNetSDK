﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

using SDNUMobile.SDK.Utilities;

namespace SDNUMobile.SDK.Net
{
    /// <summary>
    /// OAuth Http请求类
    /// </summary>
    public static class OAuthHttpClient
    {
        #region 字段
        private static Random _rand;
        #endregion

        #region 构造方法
        static OAuthHttpClient()
        {
            _rand = new Random();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 异步从指定URL Get获取内容
        /// </summary>
        /// <param name="url">指定URL</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="headers">请求头参数列表</param>
        /// <param name="callback">回调方法</param>
        public static void GetRemoteContentAsync(String url, String consumerSecret, String tokenSecret, IEnumerable<RequestParameter> headers, Action<String> callback)
        {
            OAuthHttpClient.RequestRemoteContentAsync(RequestMethod.Get, url, consumerSecret, tokenSecret, headers, null, callback);
        }

        /// <summary>
        /// 异步从指定URL Get获取内容
        /// </summary>
        /// <param name="url">指定URL</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="headers">请求头参数列表</param>
        /// <param name="queryParamerters">请求参数列表</param>
        /// <param name="callback">回调方法</param>
        public static void GetRemoteContentAsync(String url, String consumerSecret, String tokenSecret, IEnumerable<RequestParameter> headers, IEnumerable<RequestParameter> queryParamerters, Action<String> callback)
        {
            OAuthHttpClient.RequestRemoteContentAsync(RequestMethod.Get, url, consumerSecret, tokenSecret, headers, queryParamerters, callback);
        }

        /// <summary>
        /// 异步从指定URL Post获取内容
        /// </summary>
        /// <param name="url">指定URL</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="headers">请求头参数列表</param>
        /// <param name="callback">回调方法</param>
        public static void PostRemoteContentAsync(String url, String consumerSecret, String tokenSecret, IEnumerable<RequestParameter> headers, Action<String> callback)
        {
            OAuthHttpClient.RequestRemoteContentAsync(RequestMethod.Post, url, consumerSecret, tokenSecret, headers, null, callback);
        }

        /// <summary>
        /// 异步从指定URL Post获取内容
        /// </summary>
        /// <param name="url">指定URL</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="headers">请求头参数列表</param>
        /// <param name="queryParamerters">请求参数列表</param>
        /// <param name="callback">回调方法</param>
        public static void PostRemoteContentAsync(String url, String consumerSecret, String tokenSecret, IEnumerable<RequestParameter> headers, IEnumerable<RequestParameter> queryParamerters, Action<String> callback)
        {
            OAuthHttpClient.RequestRemoteContentAsync(RequestMethod.Post, url, consumerSecret, tokenSecret, headers, queryParamerters, callback);
        }

        /// <summary>
        /// 异步从指定URL获取内容
        /// </summary>
        /// <param name="method">请求方式</param>
        /// <param name="url">指定URL</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="headers">请求头参数列表</param>
        /// <param name="queryParamerters">请求参数列表</param>
        /// <param name="callback">回调方法</param>
        public static void RequestRemoteContentAsync(RequestMethod method, String url, String consumerSecret, String tokenSecret,
            IEnumerable<RequestParameter> headers, IEnumerable<RequestParameter> queryParamerters, Action<String> callback)
        {
            OAuthHttpClient.RequestRemoteContentAsync(method, url, Encoding.UTF8, true, consumerSecret, tokenSecret, headers, queryParamerters, callback);
        }

        /// <summary>
        /// 异步从指定URL获取内容
        /// </summary>
        /// <param name="method">请求方式</param>
        /// <param name="url">指定URL</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="nocache">是否禁用缓存</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="headers">请求头参数列表</param>
        /// <param name="queryParamerters">请求参数列表</param>
        /// <param name="callback">回调方法</param>
        public static void RequestRemoteContentAsync(RequestMethod method, String url, Encoding encoding, Boolean nocache, String consumerSecret, String tokenSecret,
            IEnumerable<RequestParameter> headers, IEnumerable<RequestParameter> queryParamerters, Action<String> callback)
        {
            String boundary = DateTime.Now.Ticks.ToString("x");
            String actualUrl = (method == RequestMethod.Get ? OAuthHttpClient.GetActualUrl(url, encoding, queryParamerters, nocache) : url);

            HttpWebRequest request = HttpWebRequest.Create(actualUrl) as HttpWebRequest;
            request.Method = method.ToString().ToUpperInvariant();

            if (method == RequestMethod.Post)
            {
                request.ContentType = OAuthHttpClient.IsRequestParametersHasBinaryFile(queryParamerters) ?
                    "multipart/form-data; boundary=" + boundary : "application/x-www-form-urlencoded";

                if (nocache)
                {
                    request.Headers[HttpRequestHeader.Pragma] = "no-cache";
                    request.Headers[HttpRequestHeader.CacheControl] = "no-cache";
                }
            }
            else if (method == RequestMethod.Get)
            {
                if (nocache)
                {
                    request.Headers[HttpRequestHeader.IfNoneMatch] = Guid.NewGuid().ToString();
                }
            }

            if (headers != null)
            {
                String authHeader = AuthorizationHeaderBuilder.CreateHttpAuthorizationHeader(
                    request.Method, new Uri(actualUrl), consumerSecret, tokenSecret, headers, queryParamerters);

                request.Headers[HttpRequestHeader.Authorization] = authHeader;
            }

            if (method == RequestMethod.Post)
            {
                Byte[] data = OAuthHttpClient.GetParameterDataFromList(queryParamerters, boundary, encoding);

                request.BeginGetRequestStream(ar =>
                {
                    using (Stream stream = request.EndGetRequestStream(ar))
                    {
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                    }

                    OAuthHttpClient.GetContentFromHttpWebRequest(request, encoding, callback);
                }, null);
            }
            else
            {
                OAuthHttpClient.GetContentFromHttpWebRequest(request, encoding, callback);
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获取实际Url
        /// </summary>
        /// <param name="rawUrl">原始Url</param>
        /// <param name="encoding">文字编码</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="nocache">是否添加禁用缓存参数</param>
        /// <returns>实际Url</returns>
        private static String GetActualUrl(String rawUrl, Encoding encoding, IEnumerable<RequestParameter> parameters, Boolean nocache)
        {
            if (parameters == null)
            {
                return rawUrl;
            }

            String queryString = OAuthHttpClient.GetParameterStringFromList(parameters, encoding);
            String actualUrl = String.Format("{0}{1}{2}", rawUrl, (rawUrl.LastIndexOf('?') >= 0 ? "&" : "?"), queryString);

            return actualUrl;
        }

        /// <summary>
        /// 从WebResponse中获取字节数组
        /// </summary>
        /// <param name="response">WebResponse</param>
        /// <returns>字节数组</returns>
        private static Byte[] GetBytesFromResponse(WebResponse response)
        {
            Byte[] data = null;

            using (MemoryStream ms = new MemoryStream())
            {
                Byte[] buf = new Byte[1024];
                Int32 len = 0;

                using (Stream stream = response.GetResponseStream())
                {
                    while ((len = stream.Read(buf, 0, buf.Length)) > 0)
                    {
                        ms.Write(buf, 0, len);
                    }
                }

                data = ms.ToArray();
            }

            return data;
        }

        /// <summary>
        /// 从异步结果中获取内容
        /// </summary>
        /// <param name="request">HttpWebRequest</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="callback">回调方法</param>
        private static void GetContentFromHttpWebRequest(HttpWebRequest request, Encoding encoding, Action<String> callback)
        {
            request.BeginGetResponse(ar =>
            {
                HttpWebResponse response = null;
                Byte[] data = null;
                String content = String.Empty;

                try
                {
                    response = request.EndGetResponse(ar) as HttpWebResponse;
                }
                catch (WebException we)
                {
                    response = we.Response as HttpWebResponse;
                }
                catch
                {
                    throw;
                }
                finally
                {
                    if (response != null)
                    {
                        data = OAuthHttpClient.GetBytesFromResponse(response);

#if PORTABLE40 || PORTABLE45
                        response.Dispose();
#else
                        response.Close();
#endif
                    }
                }

                if (data != null)
                {
                    content = encoding.GetString(data, 0, data.Length);
                }

                if (callback != null)
                {
                    callback(content);
                }
            }, null);
        }

        /// <summary>
        /// 从参数列表中获取参数字符串
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <param name="encoding">文字编码</param>
        /// <returns>参数字符串</returns>
        private static String GetParameterStringFromList(IEnumerable<RequestParameter> parameters, Encoding encoding)
        {
            StringBuilder sb = new StringBuilder();
            Int32 index = 0;

            foreach (RequestParameter param in parameters)
            {
                if (param.ContentType != ParameterContentType.String)
                {
                    continue;
                }

                if (index++ > 0)
                {
                    sb.Append("&");
                }

                sb.Append(param.Name).Append('=').Append(HttpUtility.UrlEncode(param.Value as String, encoding));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 从参数列表中获取参数数据
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <param name="boundary">界限标记</param>
        /// <param name="encoding">文字编码</param>
        /// <returns>参数数据</returns>
        private static Byte[] GetParameterDataFromList(IEnumerable<RequestParameter> parameters, String boundary, Encoding encoding)
        {
            Byte[] data = null;

            if (parameters == null)
            {
                return new Byte[0];
            }

            if (OAuthHttpClient.IsRequestParametersHasBinaryFile(parameters))//multipart/form-data
            {
                String boundaryLine = "\r\n--" + boundary;
                String stringTemplate = boundaryLine + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                String binaryTemplate = boundaryLine + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: \"{2}\"\r\n\r\n";
                String endBoundary = boundaryLine + "--";

                String temp = String.Empty;
                Byte[] buf = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    foreach (RequestParameter param in parameters)//先写入字符串参数
                    {
                        if (param.ContentType == ParameterContentType.String)
                        {
                            temp = String.Format(stringTemplate, param.Name, param.Value as String);
                            buf = encoding.GetBytes(temp);
                            ms.Write(buf, 0, buf.Length);
                        }
                    }

                    foreach (RequestParameter param in parameters)//再写入二进制参数
                    {
                        if (param.ContentType == ParameterContentType.Binary)
                        {
                            temp = String.Format(binaryTemplate, param.Name, param.FileName, "application/octet-stream");
                            buf = encoding.GetBytes(temp);
                            ms.Write(buf, 0, buf.Length);

                            buf = param.Value as Byte[];
                            ms.Write(buf, 0, buf.Length);
                        }
                    }

                    buf = encoding.GetBytes(endBoundary);
                    ms.Write(buf, 0, buf.Length);

                    data = ms.ToArray();
                }
            }
            else//application/x-www-form-urlencoded
            {
                String parameterString = OAuthHttpClient.GetParameterStringFromList(parameters, encoding);
                data = encoding.GetBytes(parameterString);
            }

            return data;
        }

        /// <summary>
        /// 检查请求参数中是否包含二进制文件
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <returns>是否包含二进制文件</returns>
        private static Boolean IsRequestParametersHasBinaryFile(IEnumerable<RequestParameter> parameters)
        {
            if (parameters == null)
            {
                return false;
            }

            foreach (RequestParameter parameter in parameters)
            {
                if (parameter.ContentType == ParameterContentType.Binary)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion
    }
}