using System;
using System.Collections.Generic;
using System.Text;

namespace SDNUMobile.SDK.Utilities
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
        /// <param name="queryStrings">GET请求参数列表</param>
        /// <param name="forms">POST请求参数列表</param>
        /// <returns>Http请求认证头</returns>
        public static String CreateHttpAuthorizationHeader(
            String httpMethod, Uri requestUrl, 
            String consumerSecret, String tokenSecret,
            IEnumerable<KeyValuePair<String, String>> headers, 
            IEnumerable<KeyValuePair<String, String>> queryStrings, 
            IEnumerable<KeyValuePair<String, String>> forms)
        {
            List<KeyValuePair<String, String>> allHeaders = new List<KeyValuePair<String, String>>();
            String signature = AuthorizationHeaderBuilder.CreateHttpAuthorizationSignature(httpMethod, requestUrl, consumerSecret, tokenSecret, headers, queryStrings, forms);

            foreach (KeyValuePair<String, String> pair in headers)
            {
                allHeaders.Add(pair);
            }

            allHeaders.Add(new KeyValuePair<String, String>(OAuthConstants.SignatureParameter, signature));
            allHeaders.Sort(KeyValuePairComparer<String, String>.Default);

            StringBuilder sb = new StringBuilder();
            sb.Append(OAuthConstants.AuthorizationOAuthHeader);

            Int32 index = 0;
            foreach (KeyValuePair<String, String> pair in allHeaders)
            {
                if (index++ > 0) sb.Append(',');
                sb.Append(RFC3986Encoder.Encode(pair.Key)).Append("=\"").Append(RFC3986Encoder.Encode(pair.Value)).Append("\"");
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
        /// <param name="queryStrings">GET请求参数列表</param>
        /// <param name="forms">POST请求参数列表</param>
        /// <returns>Http请求认证签名</returns>
        private static String CreateHttpAuthorizationSignature(
            String httpMethod, Uri requestUrl, 
            String consumerSecret, String tokenSecret,
            IEnumerable<KeyValuePair<String, String>> headers, 
            IEnumerable<KeyValuePair<String, String>> queryStrings, 
            IEnumerable<KeyValuePair<String, String>> forms)
        {
            List<KeyValuePair<String, String>> allParams = new List<KeyValuePair<String, String>>();

            foreach (KeyValuePair<String, String> pair in headers)
            {
                allParams.Add(pair);
            }

            if (queryStrings != null)
            {
                foreach (KeyValuePair<String, String> pair in queryStrings)
                {
                    allParams.Add(pair);
                }
            }

            if (forms != null)
            {
                foreach (KeyValuePair<String, String> pair in forms)
                {
                    allParams.Add(pair);
                }
            }

            allParams.Sort(KeyValuePairComparer<String, String>.Default);

            String signatureBase = SignatureBaseBuilder.CreateSignatureBaseString(httpMethod, requestUrl, allParams);
            String signature = HMACSHA1Signer.CreateSignature(consumerSecret, tokenSecret, signatureBase);

            return signature;
        }
        #endregion
    }
}