using System;

using SDNUMobile.SDK.Entity.Weather;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Weather
{
    /// <summary>
    /// 未来三天天气预报获取方法
    /// </summary>
    public class GetForcast : AbstractRestMethod<WeatherForcasts>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "weather/getforcast"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
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

        #region 构造方法
        /// <summary>
        /// 初始化新的未来三天天气预报获取方法
        /// </summary>
        /// <param name="areaID">区域ID</param>
        public GetForcast(String areaID)
        {
            this.AreaID = areaID;
        }
        #endregion
    }
}