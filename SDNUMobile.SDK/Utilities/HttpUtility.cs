using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// Http工具类
    /// </summary>
    public static class HttpUtility
    {
        #region 常量
        private static readonly Regex RFC3986EscapeSequence = new Regex("%([0-9A-Fa-f]{2})");
        #endregion

        #region RFC3986 Encode/Decode
        /// <summary>
        /// 对指定内容进行RFC3986编码
        /// </summary>
        /// <param name="input">要编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static String RFC3986Encode(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            Byte[] data = Encoding.UTF8.GetBytes(input);
            Int32 unsafeChars = 0;

            for (Int32 i = 0; i < data.Length; i++)
            {
                if (IsReverseCharInRFC3986((Char)data[i]))
                {
                    unsafeChars++;
                }
            }

            if (unsafeChars == 0)
            {
                return input;
            }

            Byte[] buff = new Byte[data.Length + (unsafeChars * 2)];
            Int32 pos = 0;

            for (Int32 i = 0; i < data.Length; i++)
            {
                Byte b = data[i];

                if (IsReverseCharInRFC3986((Char)b))
                {
                    buff[pos++] = (Byte)'%';
                    buff[pos++] = (Byte)IntToHex((b >> 4) & 0xF);
                    buff[pos++] = (Byte)IntToHex(b & 0x0F);
                }
                else
                {
                    buff[pos++] = b;
                }
            }

            return Encoding.UTF8.GetString(buff, 0, buff.Length);
        }

        /// <summary>
        /// 对指定内容进行RFC3986解码
        /// </summary>
        /// <param name="input">要解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static String RFC3986Decode(String input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            return HttpUtility.RFC3986EscapeSequence.Replace(input, match =>
            {
                if (match.Success)
                {
                    Group hexgrp = match.Groups[1];

                    return String.Format(CultureInfo.InvariantCulture, "{0}",
                        (Char)Int32.Parse(hexgrp.Value, NumberStyles.HexNumber, CultureInfo.InvariantCulture));
                }

                throw new FormatException();
            });
        }
        #endregion

        #region UrlEncode /UrlDecode
        /// <summary>
        /// UrlEncode
        /// </summary>
        /// <param name="input">要编码的字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>编码后的字符串</returns>
        public static String UrlEncode(String input, Encoding encoding)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            Byte[] bytes = encoding.GetBytes(input);

            for (Int32 i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x20)
                {
                    sb.Append('+');
                }
                else if (HttpUtility.IsUrlSafeChar((Char)bytes[i]))
                {
                    sb.Append((Char)bytes[i]);
                }
                else
                {
                    sb.Append(@"%" + bytes[i].ToString("x2"));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// UrlEncode
        /// </summary>
        /// <param name="input">要编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        public static String UrlEncode(String input)
        {
            return HttpUtility.UrlEncode(input, Encoding.UTF8);
        }

        /// <summary>
        /// UrlDecode
        /// </summary>
        /// <param name="input">要解码的字符串</param>
        /// <param name="encoding">编码格式</param>
        /// <returns>解码后的字符串</returns>
        public static String UrlDecode(String input, Encoding encoding)
        {
            if (String.IsNullOrEmpty(input))
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();

            for (Int32 i = 0; i < input.Length; i++)
            {
                if (input[i] == '+')
                {
                    sb.Append(' ');
                }
                else if (input[i] == '%')
                {
                    String code = "0x" + input.Substring(i + 1, 2);
                    Byte[] buf = new Byte[3];
                    buf[0] = Convert.ToByte(code, 16);

                    if (buf[0] > 0xDF)
                    {
                        buf[1] = Convert.ToByte("0x" + input.Substring(i + 4, 2), 16);
                        buf[2] = Convert.ToByte("0x" + input.Substring(i + 7, 2), 16);
                        sb.Append(encoding.GetString(buf, 0, buf.Length));
                        i += 8;
                    }
                    else if (buf[0] > 0x7F)
                    {
                        buf[1] = Convert.ToByte("0x" + input.Substring(i + 4, 2), 16);
                        sb.Append(encoding.GetString(buf, 0, buf.Length));
                        i += 5;
                    }
                    else
                    {
                        sb.Append(Convert.ToChar(buf[0]));
                        i += 2;
                    }
                }
                else
                {
                    sb.Append(input[i]);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// UrlDecode
        /// </summary>
        /// <param name="input">要解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        public static String UrlDecode(String input)
        {
            return HttpUtility.UrlDecode(input, Encoding.UTF8);
        }
        #endregion

        #region 私有方法
        private static Boolean IsReverseCharInRFC3986(Char c)
        {
            //RFC 3986
            //unreserved    = ALPHA / DIGIT / "-" / "." / "_" / "~"
            return !((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') ||
                    c == '-' || c == '.' || c == '_' || c == '~');
        }

        private static Boolean IsUrlSafeChar(Char c)
        {
            //RFC 1738
            //safe           = "$" | "-" | "_" | "." | "+"
            //extra          = "!" | "*" | "'" | "(" | ")" | ","
            //unreserved     = alpha | digit | safe | extra
            return ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') ||
                    c == '(' || c == ')' || c == '*' || c == '-' || c == '.' || c == '_' || c == '!');
        }

        private static Char IntToHex(Int32 n)
        {
            if (n < 0 || n >= 16)
            {
                throw new ArgumentOutOfRangeException("n");
            }

            if (n <= 9)
            {
                return (Char)(n + (Int32)'0');
            }
            else
            {
                return (Char)(n - 10 + (Int32)'A');
            }
        }
        #endregion
    }
}