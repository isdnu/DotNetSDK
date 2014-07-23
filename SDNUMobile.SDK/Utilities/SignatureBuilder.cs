using System;
using System.Collections.Generic;
using System.Text;

using HashLib;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// SignatureBase生成器
    /// </summary>
    public static class SignatureBuilder
    {
        #region 方法
        /// <summary>
        /// 创建签名基础字符串
        /// </summary>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="requestUrl">请求URL地址</param>
        /// <param name="parameters">请求参数列表</param>
        /// <returns>签名基础字符串</returns>
        public static String CreateSignatureBaseString(String httpMethod, Uri requestUrl, IEnumerable<RequestParameter> parameters)
        {
            StringBuilder sb = new StringBuilder();

            /*
                httpMethod + "&" +
                url_encode(  base_uri ) + "&" +
                sorted_query_params.each  { | k, v |
                    url_encode ( k ) + "%3D" +
                    url_encode ( v )
                }.join("%26")
            */

            String baseUri = String.Format("{0}://{1}{2}", 
                requestUrl.Scheme, 
                requestUrl.GetComponents(UriComponents.Host | UriComponents.Port, UriFormat.UriEscaped).ToLowerInvariant(), 
                requestUrl.AbsolutePath);

            sb.Append(httpMethod).Append("&");
            sb.Append(HttpUtility.RFC3986Encode(baseUri)).Append("&");
            sb.Append(HttpUtility.RFC3986Encode(SignatureBuilder.GetJoinedParameter(parameters)));

            return sb.ToString();
        }

        /// <summary>
        /// 创建签名字符串
        /// </summary>
        /// <param name="consumerSecret">应用密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="signatureBase">SignatureBase</param>
        /// <returns>签名字符串</returns>
        public static String CreateSignature(String consumerSecret, String tokenSecret, String signatureBase)
        {
            String key = HttpUtility.RFC3986Encode(consumerSecret) + "&" + HttpUtility.RFC3986Encode(tokenSecret);

            Byte[] data = null;
            String hash = String.Empty;
            
            HMACSHA1 crypto = new HMACSHA1();
            crypto.Key = Encoding.UTF8.GetBytes(key);

            data = crypto.ComputeHash(Encoding.UTF8.GetBytes(signatureBase));
            hash = Convert.ToBase64String(data);

            return hash;
        }
        #endregion

        #region 私有方法
        private static String GetJoinedParameter(IEnumerable<RequestParameter> parameters)
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
                    sb.Append('&');
                }

                sb.Append(param.Name).Append('=').Append(param.Value as String);
            }

            return sb.ToString();
        }
        #endregion
    }
}