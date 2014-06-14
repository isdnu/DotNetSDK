using System;

namespace SDNUMobile.SDK.Entity.User
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType : byte
    {
        /// <summary>
        /// 本科生
        /// </summary>
        Undergraduate = 0,

        /// <summary>
        /// 研究生
        /// </summary>
        Postgraduate = 1,

        /// <summary>
        /// 教职工
        /// </summary>
        Teacher = 2
    }
}