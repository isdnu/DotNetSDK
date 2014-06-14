using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Weather
{
    /// <summary>
    /// 天气城市信息实体
    /// </summary>
    public class WeatherCityInfo
    {
        #region 字段
        private String _areaID;
        private String _englishName;
        private String _chineseName;
        private String _longitude;
        private String _latitude;
        private String _elevation;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置区域ID
        /// </summary>
        [JsonProperty("areaID")]
        public String AreaID
        {
            get { return this._areaID; }
            set { this._areaID = value; }
        }

        /// <summary>
        /// 获取或设置城市英文名
        /// </summary>
        [JsonProperty("englishName")]
        public String EnglishName
        {
            get { return this._englishName; }
            set { this._englishName = value; }
        }

        /// <summary>
        /// 获取或设置城市中文名
        /// </summary>
        [JsonProperty("chineseName")]
        public String ChineseName
        {
            get { return this._chineseName; }
            set { this._chineseName = value; }
        }

        /// <summary>
        /// 获取或设置经度
        /// </summary>
        [JsonProperty("longitude")]
        public String Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
        }

        /// <summary>
        /// 获取或设置纬度
        /// </summary>
        [JsonProperty("latitude")]
        public String Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }

        /// <summary>
        /// 获取或设置海拔
        /// </summary>
        [JsonProperty("elevation")]
        public String Elevation
        {
            get { return this._elevation; }
            set { this._elevation = value; }
        }
        #endregion
    }
}