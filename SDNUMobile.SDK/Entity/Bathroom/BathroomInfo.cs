using System;

namespace SDNUMobile.SDK.Entity.Bathroom
{
    /// <summary>
    /// 浴室信息实体
    /// </summary>
    public class BathroomInfo
    {
        #region 字段
        private Int32 _bathroomID;
        private CampusType _bathroomCampusType;
        private String _bathroomName;
        private Int32 _bathroomSize;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置浴室ID
        /// </summary>
        public Int32 BathroomID
        {
            get { return this._bathroomID; }
            set { this._bathroomID = value; }
        }

        /// <summary>
        /// 获取或设置浴室所属校区
        /// </summary>
        public CampusType BathroomCampusType
        {
            get { return this._bathroomCampusType; }
            set { this._bathroomCampusType = value; }
        }

        /// <summary>
        /// 获取或设置浴室名称
        /// </summary>
        public String BathroomName
        {
            get { return this._bathroomName; }
            set { this._bathroomName = value; }
        }

        /// <summary>
        /// 获取或设置浴室容量
        /// </summary>
        public Int32 BathroomSize
        {
            get { return this._bathroomSize; }
            set { this._bathroomSize = value; }
        }
        #endregion
    }
}