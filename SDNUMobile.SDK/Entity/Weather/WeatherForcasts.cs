using System;

namespace SDNUMobile.SDK.Entity.Weather
{
    /// <summary>
    /// 天气预报信息实体
    /// </summary>
    public class WeatherForcasts
    {
        #region 字段
        private WeatherCityInfo _cityInfo;
        private WeatherForcast[] _forcasts;
        private DateTime _forcastPublishTime;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置城市信息
        /// </summary>
        public WeatherCityInfo CityInfo
        {
            get { return this._cityInfo; }
            set { this._cityInfo = value; }
        }

        /// <summary>
        /// 获取或设置预报信息
        /// </summary>
        public WeatherForcast[] Forcasts
        {
            get { return this._forcasts; }
            set { this._forcasts = value; }
        }

        /// <summary>
        /// 获取或设置预报发布时间
        /// </summary>
        public DateTime ForcastPublishTime
        {
            get { return this._forcastPublishTime; }
            set { this._forcastPublishTime = value; }
        }
        #endregion
    }
}