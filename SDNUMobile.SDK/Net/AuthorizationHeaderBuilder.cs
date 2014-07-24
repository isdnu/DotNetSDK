using System;
using System.Collections.Generic;
using System.Text;

using SDNUMobile.SDK.Utilities;

namespace SDNUMobile.SDK.Net
{
    /// <summary>
    /// OAuth请求头部生成器
    /// </summary>
    public static class AuthorizationHeaderBuilder
    {
        #region 方法
        /// <summary>
        /// 创建Http请求认证头
        /// </summary>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="requestUrl">请求URL地址</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="headers">请求头参数列表</param>
        /// <param name="parameters">请求参数列表</param>
        /// <returns>Http请求认证头</returns>
        public static String CreateHttpAuthorizationHeader(
            String httpMethod, Uri requestUrl,  String consumerSecret, String tokenSecret,
            IEnumerable<RequestParameter> headers, IEnumerable<RequestParameter> parameters)
        {
            List<RequestParameter> allHeaders = new List<RequestParameter>();
            String signature = AuthorizationHeaderBuilder.CreateHttpAuthorizationSignature(
                httpMethod, requestUrl, consumerSecret, tokenSecret, headers, parameters);

            if (headers != null)
            {
                foreach (RequestParameter param in headers)
                {
                    allHeaders.Add(param);
                }
            }

            allHeaders.Add(new RequestParameter(OAuthConstants.SignatureParameter, signature));
            allHeaders.Sort(RequestParameterComparer.Default);

            StringBuilder sb = new StringBuilder();
            sb.Append(OAuthConstants.AuthorizationOAuthHeader);

            Int32 index = 0;
            foreach (RequestParameter param in allHeaders)
            {
                if (param.ContentType != ParameterContentType.String)
                {
                    continue;
                }

                if (index++ > 0)
                {
                    sb.Append(',');
                }

                sb.Append(HttpUtility.RFC3986Encode(param.Name)).Append("=\"").Append(HttpUtility.RFC3986Encode(param.Value as String)).Append("\"");
            }

            return sb.ToString();
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 创建Http请求认证签名
        /// </summary>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="requestUrl">请求URL地址</param>
        /// <param name="consumerSecret">客户端密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="headers">请求头参数列表</param>
        /// <param name="parameters">请求参数列表</param>
        /// <returns>Http请求认证签名</returns>
        private static String CreateHttpAuthorizationSignature(
            String httpMethod, Uri requestUrl, String consumerSecret, String tokenSecret,
            IEnumerable<RequestParameter> headers, IEnumerable<RequestParameter> parameters)
        {
            List<RequestParameter> allParams = new List<RequestParameter>();

            if (headers != null)
            {
                foreach (RequestParameter param in headers)
                {
                    allParams.Add(param);
                }
            }

            if (parameters != null)
            {
                foreach (RequestParameter param in parameters)
                {
                    allParams.Add(param);
                }
            }

            allParams.Sort(RequestParameterComparer.Default);

            String signatureBase = SignatureBuilder.CreateSignatureBaseString(httpMethod, requestUrl, allParams);
            String signature = SignatureBuilder.CreateSignature(consumerSecret, tokenSecret, signatureBase);

            return signature;
        }
        #endregion
    }
}