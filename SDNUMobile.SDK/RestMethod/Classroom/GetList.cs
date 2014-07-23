using System;

using SDNUMobile.SDK.Entity.Classroom;

namespace SDNUMobile.SDK.RestMethod.Classroom
{
    /// <summary>
    /// 空闲教室信息获取方法
    /// </summary>
    public class GetList : AbstractRestMethod
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "classroom/getlist"; }
        }

        /// <summary>
        /// 获取返回实体类型
        /// </summary>
        public override Type ResultEntityType
        {
            get { return typeof(ClassroomAvailable[]); }
        }

        /// <summary>
        /// 获取或设置开始日期时间
        /// </summary>
        public DateTime? StartTime
        {
            get { return this.GetParameterDateTimeValue("start"); }
            set { this.SetParameter("start", value.Value); }
        }

        /// <summary>
        /// 获取或设置查询教学楼
        /// </summary>
        public String Building
        {
            get { return this.GetParameterStringValue("building"); }
            set { this.SetParameter("building", value); }
        }
        #endregion
    }
}