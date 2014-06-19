using System;

namespace SDNUMobile.SDK.Entity.Card
{
    /// <summary>
    /// 一卡通流水商户类型
    /// </summary>
    public enum CommercialTenantType : byte
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 服务
        /// </summary>
        Service = 1,

        /// <summary>
        /// 食堂
        /// </summary>
        Cafeteria = 2,

        /// <summary>
        /// 图书馆
        /// </summary>
        Library = 3,

        /// <summary>
        /// 医院
        /// </summary>
        Hospital = 4,

        /// <summary>
        /// 超市
        /// </summary>
        Supermarket = 5,

        /// <summary>
        /// 水房
        /// </summary>
        Waterroom = 6,

        /// <summary>
        /// 浴室
        /// </summary>
        Bathroom = 7
    }
}