using System;

using SDNUMobile.SDK.Entity.Bathroom;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Bathroom
{
    /// <summary>
    /// 浴室使用状态获取方法
    /// </summary>
    public class GetStatus : AbstractRestMethod<BathroomUsageAmounts>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "bathroom/getstatus"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
        }

        /// <summary>
        /// 获取或设置与当日相差天数
        /// </summary>
        public Int32? Day
        {
            get { return this.GetParameterInt32Value("day"); }
            set { this.SetParameter("day", value); }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的浴室使用状态获取方法
        /// </summary>
        public GetStatus() { }

        /// <summary>
        /// 初始化新的浴室使用状态获取方法
        /// </summary>
        /// <param name="day">与当日相差天数</param>
        public GetStatus(Int32 day)
        {
            this.Day = day;
        }
        #endregion
    }
}