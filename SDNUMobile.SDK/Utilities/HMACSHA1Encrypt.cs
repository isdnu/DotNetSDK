using System;
using System.Text;

using HashLib;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// HMAC-SHA1加密类
    /// </summary>
    public static class HMACSHA1Encrypt
    {
        /// <summary>
        /// 返回HMAC-SHA1加密字节数组
        /// </summary>
        /// <param name="key">加密密钥数据</param>
        /// <param name="origin">待加密的数据</param>
        /// <returns>HMAC-SHA1加密结果字节数组</returns>
        public static Byte[] EncryptToByteArray(Byte[] key, Byte[] origin)
        {
            if (origin == null)
            {
                return new Byte[0];
            }

            Byte[] data = null;
            HMACSHA1 crypto = new HMACSHA1();

            crypto.Key = key;
            data = crypto.ComputeHash(origin);
            
            return data;
        }

        /// <summary>
        /// 返回HMAC-SHA1十六进制加密字符串
        /// </summary>
        /// <param name="key">加密密钥数据</param>
        /// <param name="origin">待加密的数据</param>
        /// <param name="upperCase">是否大写</param>
        /// <returns>HMAC-SHA1十六进制加密字符串</returns>
        public static String EncryptToHexString(Byte[] key, Byte[] origin, Boolean upperCase)
        {
            Byte[] data = EncryptToByteArray(key, origin);

            StringBuilder sb = new StringBuilder();
            String format = (upperCase ? "X2" : "x2");
            for (Int32 i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString(format));
            }

            return sb.ToString();
        }

        /// <summary>
        /// 返回HMAC-SHA1十六进制加密字符串
        /// </summary>
        /// <param name="key">加密密钥字符串</param>
        /// <param name="origin">待加密的字符串</param>
        /// <param name="upperCase">是否大写</param>
        /// <returns>HMAC-SHA1十六进制加密字符串</returns>
        public static String EncryptToHexString(String key, String origin, Boolean upperCase)
        {
            Byte[] keyData = Encoding.UTF8.GetBytes(key);
            Byte[] originData = Encoding.UTF8.GetBytes(origin);

            return EncryptToHexString(keyData, originData, upperCase);
        }

        /// <summary>
        /// 返回HMAC-SHA1加密Base64字符串
        /// </summary>
        /// <param name="key">加密密钥数据</param>
        /// <param name="origin">待加密的数据</param>
        /// <returns>HMAC-SHA1 Base64加密字符串</returns>
        public static String EncryptToBase64String(Byte[] key, Byte[] origin)
        {
            Byte[] data = EncryptToByteArray(key, origin);
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// 返回HMAC-SHA1加密Base64字符串
        /// </summary>
        /// <param name="key">加密密钥字符串</param>
        /// <param name="origin">待加密的字符串</param>
        /// <returns>HMAC-SHA1 Base64加密字符串</returns>
        public static String EncryptToBase64String(String key, String origin)
        {
            Byte[] keyData = Encoding.UTF8.GetBytes(key);
            Byte[] originData = Encoding.UTF8.GetBytes(origin);

            return EncryptToBase64String(keyData, originData);
        }
    }
}