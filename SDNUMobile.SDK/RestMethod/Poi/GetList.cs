using System;

using SDNUMobile.SDK.Entity.Poi;

namespace SDNUMobile.SDK.RestMethod.Poi
{
    /// <summary>
    /// 学校地理位置信息获取方法
    /// </summary>
    public class GetList : AbstractRestMethod
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "poi/getlist"; }
        }

        /// <summary>
        /// 获取返回实体类型
        /// </summary>
        public override Type ResultEntityType
        {
            get { return typeof(SchoolPosition[]); }
        }

        /// <summary>
        /// 获取或设置地理坐标类型
        /// </summary>
        public PositionType Type
        {
            get { return (String.Equals(this.GetParameterStringValue("type"), "gcj") ? PositionType.GCJ_02 : PositionType.BD_09); }
            set { this.SetParameter("type", (value == PositionType.GCJ_02 ? "gcj" : "bd")); }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的学校地理位置信息获取方法
        /// </summary>
        public GetList() { }

        /// <summary>
        /// 初始化新的学校地理位置信息获取方法
        /// </summary>
        /// <param name="type">地理坐标类型</param>
        public GetList(PositionType type)
        {
            this.Type = type;
        }
        #endregion
    }
}