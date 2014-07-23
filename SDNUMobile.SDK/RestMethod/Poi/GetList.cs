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
        #endregion
    }
}