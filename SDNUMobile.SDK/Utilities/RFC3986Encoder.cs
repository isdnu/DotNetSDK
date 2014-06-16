using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// RFC3986编码器
    /// </summary>
    public static class RFC3986Encoder
    {
        #region 常量
        private static readonly Regex RFC3986EscapeSequence = new Regex("%([0-9A-Fa-f]{2})");
        #endregion

        #region 方法
        /// <summary>
        /// 对指定内容进行RFC3986编码
        /// </summary>
        /// <param name="input">要编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static String Encode(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();

            for (Int32 i = 0; i < input.Length; i++)
            {
                Char c = input[i];

                if (IsReverseChar(c))
                {
                    sb.Append("%");
                    sb.Append(((Byte)c).ToString("X2"));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 对指定内容进行RFC3986解码
        /// </summary>
        /// <param name="input">要解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static String Decode(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            return RFC3986Encoder.RFC3986EscapeSequence.Replace(input,
                (Match match) =>
                {
                    if (match.Success)
                    {
                        Group hexgrp = match.Groups[1];

                        return String.Format(CultureInfo.InvariantCulture, "{0}",
                            (Char)Int32.Parse(hexgrp.Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
                    }

                    throw new FormatException("无法解码指定字符串");
                });
        }
        #endregion

        #region 私有方法
        private static Boolean IsReverseChar(Char c)
        {
            return !((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')
                    || c == '-' || c == '_' || c == '.' || c == '~');
        }
        #endregion
    }
}