using System;

using SDNUMobile.SDK.Entity.Library;

namespace SDNUMobile.SDK.RestMethod.Library
{
    /// <summary>
    /// 图书馆欠费信息获取方法
    /// </summary>
    public class GetArrearList : AbstractRestMethod
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "library/getarrearlist"; }
        }

        /// <summary>
        /// 获取返回实体类型
        /// </summary>
        public override Type ResultEntityType
        {
            get { return typeof(LibraryArrearInfo[]); }
        }

        /// <summary>
        /// 获取或设置开始日期
        /// </summary>
        public DateTime? StartTime
        {
            get { return this.GetParameterDateTimeValue("start"); }
            set { this.SetParameter("start", value.Value); }
        }

        /// <summary>
        /// 获取或设置结束日期
        /// </summary>
        public DateTime? EndTime
        {
            get { return this.GetParameterDateTimeValue("end"); }
            set { this.SetParameter("end", value.Value); }
        }

        /// <summary>
        /// 获取或设置返回数量
        /// </summary>
        public Int32? Count
        {
            get { return this.GetParameterInt32Value("count"); }
            set { this.SetParameter("count", value.Value); }
        }

        /// <summary>
        /// 获取或设置返回页码
        /// </summary>
        public Int32? Index
        {
            get { return this.GetParameterInt32Value("index"); }
            set { this.SetParameter("index", value.Value); }
        }
        #endregion
    }
}