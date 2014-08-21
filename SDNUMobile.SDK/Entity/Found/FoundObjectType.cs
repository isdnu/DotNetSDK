using System;

namespace SDNUMobile.SDK.Entity.Found
{
    /// <summary>
    /// 失物招领类型
    /// </summary>
    public enum FoundObjectType : byte
    {
        /// <summary>
        /// 未知类型
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// 一卡通
        /// </summary>
        SmartCard = 1,

        /// <summary>
        /// 钱包
        /// </summary>
        Wallet = 2,

        /// <summary>
        /// 手机
        /// </summary>
        Cellphone = 3,

        /// <summary>
        /// 书籍
        /// </summary>
        Book = 4,

        /// <summary>
        /// 笔记
        /// </summary>
        Notebook = 5,

        /// <summary>
        /// 书包
        /// </summary>
        Bag = 6,

        /// <summary>
        /// 其他电子产品
        /// </summary>
        OtherElectronicProduct = 100,

        /// <summary>
        /// 其他
        /// </summary>
        Other = 255
    }
}