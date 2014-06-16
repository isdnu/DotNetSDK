using System;
using System.Collections.Generic;
using System.Text;

using HashLib;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// HMAC-SHA1签名生成器
    /// </summary>
    public static class HMACSHA1Signer
    {
        /// <summary>
        /// 创建签名字符串
        /// </summary>
        /// <param name="consumerSecret">应用密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="signatureBase">SignatureBase</param>
        /// <returns>签名字符串</returns>
        public static String CreateSignature(String consumerSecret, String tokenSecret, String signatureBase)
        {
            String key = RFC3986Encoder.Encode(consumerSecret) + "&" + RFC3986Encoder.Encode(tokenSecret);

            IHMAC crypto = HashFactory.HMAC.CreateHMAC(HashFactory.Crypto.CreateSHA1());
            crypto.Key = Encoding.UTF8.GetBytes(key);

            HashResult result = crypto.ComputeBytes(Encoding.UTF8.GetBytes(signatureBase));
            Byte[] resultData = result.GetBytes();
            String encodedResult = Convert.ToBase64String(resultData);

            return encodedResult;
        }

        /// <summary>
        /// 验证签名是否有效
        /// </summary>
        /// <param name="currentSignature">当前签名密钥</param>
        /// <param name="consumerSecret">应用密钥</param>
        /// <param name="tokenSecret">令牌密钥</param>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="requestUrl">请求URL地址</param>
        /// <param name="parameters">请求参数列表</param>
        /// <returns>签名是否有效</returns>
        public static Boolean CheckSignature(String currentSignature, String consumerSecret, String tokenSecret, String httpMethod, Uri requestUrl, IDictionary<String, String> parameters)
        {
            String sigBase = SignatureBaseBuilder.CreateSignatureBaseString(httpMethod, requestUrl, parameters);
            String expectedSignature = HMACSHA1Signer.CreateSignature(consumerSecret, tokenSecret, sigBase);
            String actualSignature = RFC3986Encoder.Decode(currentSignature);

            return String.Equals(expectedSignature, actualSignature);
        }
    }
}