using System;
using System.Text;

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
            String key = HttpUtility.RFC3986Encode(consumerSecret) + "&" + HttpUtility.RFC3986Encode(tokenSecret);
            String result = HMACSHA1Encrypt.EncryptToBase64String(key, signatureBase);

            return result;
        }
    }
}