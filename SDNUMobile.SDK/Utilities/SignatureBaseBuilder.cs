using System;
using System.Collections.Generic;
using System.Text;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// SignatureBase生成器
    /// </summary>
    public static class SignatureBaseBuilder
    {
        #region 方法
        /// <summary>
        /// 创建签名基础字符串
        /// </summary>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="requestUrl">请求URL地址</param>
        /// <param name="parameters">请求参数列表</param>
        /// <returns>签名基础字符串</returns>
        public static String CreateSignatureBaseString(String httpMethod, Uri requestUrl, IEnumerable<KeyValuePair<String, String>> parameters)
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

            sb.Append(httpMethod).Append("&");

            sb.Append(RFC3986Encoder.Encode(requestUrl.Scheme)).Append(RFC3986Encoder.Encode("://"));
            sb.Append(RFC3986Encoder.Encode(requestUrl.GetComponents(UriComponents.Host | UriComponents.Port, UriFormat.UriEscaped).ToLowerInvariant()));
            sb.Append(RFC3986Encoder.Encode(requestUrl.AbsolutePath)).Append("&");

            sb.Append(RFC3986Encoder.Encode(SignatureBaseBuilder.GetJoinedParameter(parameters)));

            return sb.ToString();
        }
        #endregion

        #region 私有方法
        private static String GetJoinedParameter(IEnumerable<KeyValuePair<String, String>> parameters)
        {
            StringBuilder sb = new StringBuilder();
            Boolean isFirst = true;

            foreach (KeyValuePair<String, String> pair in parameters)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    sb.Append('&');
                }

                sb.Append(pair.Key).Append('=').Append(pair.Value);
            }

            return sb.ToString();
        }
        #endregion
    }
}