using System;

namespace SDNUMobile.SDK.Entity.Poi
{
    /// <summary>
    /// 建筑物类型
    /// </summary>
    public enum AreaType : byte
    {
        /// <summary>
        /// 必须显示的区域
        /// </summary>
        EssentialArea = 0,

        /// <summary>
        /// 办公区
        /// </summary>
        OfficeArea = 1,

        /// <summary>
        /// 教学区
        /// </summary>
        TeachingArea = 2,

        /// <summary>
        /// 生活区
        /// </summary>
        DormitoryArea = 3,

        /// <summary>
        /// 运动区
        /// </summary>
        SportingArea = 4,

        /// <summary>
        /// 第三方区域
        /// </summary>
        ThreePartyArea = 5
    }
}