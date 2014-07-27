using System;

namespace SDNUMobile.SDK.Entity.Poi
{
    /// <summary>
    /// 地理坐标类型
    /// </summary>
    public enum PositionType : byte
    {
        /// <summary>
        /// 国内通用坐标系
        /// </summary>
        GCJ_02 = 0,

        /// <summary>
        /// 百度坐标系
        /// </summary>
        BD_09 = 1
    }
}