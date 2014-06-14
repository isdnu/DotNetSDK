using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Weather
{
    /// <summary>
    /// 天气实时信息实体
    /// </summary>
    public class WeatherRealtime
    {
        #region 字段
        private String _currentTemperature;
        private String _currentHumidity;
        private String _currentWindPower;
        private String _currentWindDirectionID;
        private String _currentWindDirectionName;
        private String _publishTime;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置当前温度（摄氏度）
        /// </summary>
        [JsonProperty("currentTemperature")]
        public String CurrentTemperature
        {
            get { return this._currentTemperature; }
            set { this._currentTemperature = value; }
        }

        /// <summary>
        /// 获取或设置当前湿度（%）
        /// </summary>
        [JsonProperty("currentHumidity")]
        public String CurrentHumidity
        {
            get { return this._currentHumidity; }
            set { this._currentHumidity = value; }
        }

        /// <summary>
        /// 获取或设置当前风力（级）
        /// </summary>
        [JsonProperty("currentWindPower")]
        public String CurrentWindPower
        {
            get { return this._currentWindPower; }
            set { this._currentWindPower = value; }
        }

        /// <summary>
        /// 获取或设置当前风向编号
        /// </summary>
        [JsonProperty("currentWindDirectionID")]
        public String CurrentWindDirectionID
        {
            get { return this._currentWindDirectionID; }
            set { this._currentWindDirectionID = value; }
        }

        /// <summary>
        /// 获取或设置当前风向名称
        /// </summary>
        [JsonProperty("currentWindDirectionName")]
        public String CurrentWindDirectionName
        {
            get { return this._currentWindDirectionName; }
            set { this._currentWindDirectionName = value; }
        }

        /// <summary>
        /// 获取或设置实时发布时间
        /// </summary>
        [JsonProperty("publishTime")]
        public String PublishTime
        {
            get { return this._publishTime; }
            set { this._publishTime = value; }
        }
        #endregion
    }
}