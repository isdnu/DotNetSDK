using System;

using SDNUMobile.SDK.Entity.Weather;

namespace SDNUMobile.SDK.RestMethod.Weather
{
    /// <summary>
    /// 未来三天天气预报获取方法
    /// </summary>
    public class GetForcast : AbstractRestMethod
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
        /// 获取返回实体类型
        /// </summary>
        public override Type ResultEntityType
        {
            get { return typeof(WeatherForcasts); }
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

        #region 方法
        /// <summary>
        /// 尝试验证方法内参数
        /// </summary>
        /// <param name="error">错误信息（如果存在）</param>
        /// <returns>参数验证是否通过</returns>
        public override Boolean TryValidateParameters(out String error)
        {
            if (String.IsNullOrEmpty(this.AreaID))
            {
                error = "区域ID不能为空！";
                return false;
            }

            error = String.Empty;
            return true;
        }
        #endregion
    }
}