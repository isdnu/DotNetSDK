using System;

using SDNUMobile.SDK.Entity.Classroom;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Classroom
{
    /// <summary>
    /// 空闲教室信息获取方法
    /// </summary>
    public class GetList : AbstractRestMethod<ClassroomAvailable[]>
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
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
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

        #region 构造方法
        /// <summary>
        /// 初始化新的空闲教室信息获取方法
        /// </summary>
        public GetList() { }

        /// <summary>
        /// 初始化新的空闲教室信息获取方法
        /// </summary>
        /// <param name="startTime">开始日期时间</param>
        /// <param name="building">查询教学楼</param>
        public GetList(DateTime startTime, String building)
        {
            this.StartTime = startTime;
            this.Building = building;
        }
        #endregion
    }
}