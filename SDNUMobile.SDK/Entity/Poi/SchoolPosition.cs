using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Poi
{
    /// <summary>
    /// 学校位置信息实体
    /// </summary>
    public class SchoolPosition
    {
        #region 字段
        private Int32 _positionID;
        private String _positionName;
        private CampusType _campusType;
        private AreaType _areaType;
        private Double _longitude;
        private Double _latitude;
        private Boolean _isHide;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置位置ID
        /// </summary>
        [JsonProperty("positionID")]
        public Int32 PositionID
        {
            get { return this._positionID; }
            set { this._positionID = value; }
        }

        /// <summary>
        /// 获取或设置位置名称
        /// </summary>
        [JsonProperty("positionName")]
        public String PositionName
        {
            get { return this._positionName; }
            set { this._positionName = value; }
        }

        /// <summary>
        /// 获取或设置校区类型
        /// </summary>
        [JsonProperty("campusType")]
        public CampusType CampusType
        {
            get { return this._campusType; }
            set { this._campusType = value; }
        }

        /// <summary>
        /// 获取或设置建筑物类型
        /// </summary>
        [JsonProperty("areaType")]
        public AreaType AreaType
        {
            get { return this._areaType; }
            set { this._areaType = value; }
        }

        /// <summary>
        /// 获取或设置精度
        /// </summary>
        [JsonProperty("longitude")]
        public Double Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
        }

        /// <summary>
        /// 获取或设置纬度
        /// </summary>
        [JsonProperty("latitude")]
        public Double Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }

        /// <summary>
        /// 获取或设置是否隐藏
        /// </summary>
        [JsonProperty("isHide")]
        public Boolean IsHide
        {
            get { return this._isHide; }
            set { this._isHide = value; }
        }
        #endregion
    }
}