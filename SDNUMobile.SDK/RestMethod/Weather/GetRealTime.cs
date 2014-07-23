using System;

using SDNUMobile.SDK.Entity.Weather;

namespace SDNUMobile.SDK.RestMethod.Weather
{
    /// <summary>
    /// 实时天气信息获取方法
    /// </summary>
    public class GetRealTime : AbstractRestMethod
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "weather/getrealtime"; }
        }

        /// <summary>
        /// 获取返回实体类型
        /// </summary>
        public override Type ResultEntityType
        {
            get { return typeof(WeatherRealtime); }
        }

        /// <summary>
        /// 获取或设置区域ID
        /// </summary>
        public String AreaID
        {
            get { return this.GetParameterStringValue("areaid"); }
            set { this.SetParameter("areaid", value); }
        }
        #endregion
    }
}