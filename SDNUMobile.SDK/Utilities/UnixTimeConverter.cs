using System;

namespace SDNUMobile.SDK.Utilities
{
    /// <summary>
    /// Unix时间转换器
    /// </summary>
    public static class UnixTimeConverter
    {
        #region 常量
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, 0);
        #endregion

        #region 方法
        /// <summary>
        /// 将系统时间转换为Unix时间
        /// </summary>
        /// <param name="time">系统时间</param>
        /// <returns>Unix时间</returns>
        public static Int64 ToUnixTime(DateTime time)
        {
            return (Int64)(time.ToUniversalTime() - UnixEpoch).TotalSeconds;
        }

        /// <summary>
        /// 将系统时间转换为系统时间
        /// </summary>
        /// <param name="unixTime">Unix时间</param>
        /// <returns>系统时间</returns>
        public static DateTime FromUnixTime(Int64 unixTime)
        {
            if (unixTime < 0)
            {
                throw new ArgumentOutOfRangeException("unixTime");
            }

            return UnixEpoch.AddSeconds(unixTime);
        }
        #endregion
    }
}