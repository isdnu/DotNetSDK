using System;

namespace SDNUMobile.SDK.Entity.Weather
{
    /// <summary>
    /// 天气预报单日信息实体
    /// </summary>
    public class WeatherForcast
    {
        #region 字段
        private String _daytimeTypeID;
        private String _daytimeTypeName;
        private String _nighttimeTypeID;
        private String _nighttimeTypeName;
        
        private String _daytimeTemperature;
        private String _nighttimeTemperature;

        private String _daytimeWindDirectionID;
        private String _daytimeWindDirectionName;
        private String _nighttimeWindDirectionID;
        private String _nighttimeWindDirectionName;

        private String _daytimeWindPowerID;
        private String _daytimeWindPowerName;
        private String _nighttimeWindPowerID;
        private String _nighttimeWindPowerName;
        
        private String _sunriseTime;
        private String _sunsetTime;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置白天天气现象编号
        /// </summary>
        public String DaytimeTypeID
        {
            get { return this._daytimeTypeID; }
            set { this._daytimeTypeID = value; }
        }

        /// <summary>
        /// 获取或设置白天天气现象名称
        /// </summary>
        public String DaytimeTypeName
        {
            get { return this._daytimeTypeName; }
            set { this._daytimeTypeName = value; }
        }

        /// <summary>
        /// 获取或设置晚上天气现象编号
        /// </summary>
        public String NighttimeTypeID
        {
            get { return this._nighttimeTypeID; }
            set { this._nighttimeTypeID = value; }
        }

        /// <summary>
        /// 获取或设置晚上天气现象名称
        /// </summary>
        public String NighttimeTypeName
        {
            get { return this._nighttimeTypeName; }
            set { this._nighttimeTypeName = value; }
        }

        /// <summary>
        /// 获取或设置白天天气温度（摄氏度）
        /// </summary>
        public String DaytimeTemperature
        {
            get { return this._daytimeTemperature; }
            set { this._daytimeTemperature = value; }
        }

        /// <summary>
        /// 获取或设置晚上天气温度（摄氏度）
        /// </summary>
        public String NighttimeTemperature
        {
            get { return this._nighttimeTemperature; }
            set { this._nighttimeTemperature = value; }
        }

        /// <summary>
        /// 获取或设置白天风向编号
        /// </summary>
        public String DaytimeWindDirectionID
        {
            get { return this._daytimeWindDirectionID; }
            set { this._daytimeWindDirectionID = value; }
        }

        /// <summary>
        /// 获取或设置白天风向名称
        /// </summary>
        public String DaytimeWindDirectionName
        {
            get { return this._daytimeWindDirectionName; }
            set { this._daytimeWindDirectionName = value; }
        }

        /// <summary>
        /// 获取或设置晚上风向编号
        /// </summary>
        public String NighttimeWindDirectionID
        {
            get { return this._nighttimeWindDirectionID; }
            set { this._nighttimeWindDirectionID = value; }
        }

        /// <summary>
        /// 获取或设置晚上风向名称
        /// </summary>
        public String NighttimeWindDirectionName
        {
            get { return this._nighttimeWindDirectionName; }
            set { this._nighttimeWindDirectionName = value; }
        }

        /// <summary>
        /// 获取或设置白天风力编号
        /// </summary>
        public String DaytimeWindPowerID
        {
            get { return this._daytimeWindPowerID; }
            set { this._daytimeWindPowerID = value; }
        }

        /// <summary>
        /// 获取或设置白天风力名称
        /// </summary>
        public String DaytimeWindPowerName
        {
            get { return this._daytimeWindPowerName; }
            set { this._daytimeWindPowerName = value; }
        }

        /// <summary>
        /// 获取或设置晚上风力编号
        /// </summary>
        public String NighttimeWindPowerID
        {
            get { return this._nighttimeWindPowerID; }
            set { this._nighttimeWindPowerID = value; }
        }

        /// <summary>
        /// 获取或设置晚上风力名称
        /// </summary>
        public String NighttimeWindPowerName
        {
            get { return this._nighttimeWindPowerName; }
            set { this._nighttimeWindPowerName = value; }
        }

        /// <summary>
        /// 获取或设置日出时间
        /// </summary>
        public String SunriseTime
        {
            get { return this._sunriseTime; }
            set { this._sunriseTime = value; }
        }

        /// <summary>
        /// 获取或设置日落时间
        /// </summary>
        public String SunsetTime
        {
            get { return this._sunsetTime; }
            set { this._sunsetTime = value; }
        }
        #endregion
    }
}