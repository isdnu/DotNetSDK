using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.People
{
    /// <summary>
    /// 人员信息实体
    /// </summary>
    public class PeopleInfo
    {
        #region 字段
        private String _identityNumber;
        private String _name;
        private String _idCardNumberHash;
        private String _sex;
        private String _nation;
        private String _organizationID;
        private String _organizationName;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置身份认证号
        /// </summary>
        [JsonProperty("identityNumber")]
        public String IdentityNumber
        {
            get { return this._identityNumber; }
            set { this._identityNumber = value; }
        }

        /// <summary>
        /// 获取或设置姓名
        /// </summary>
        [JsonProperty("name")]
        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// 获取或设置身份证号哈希值
        /// </summary>
        [JsonProperty("idCardNumberHash")]
        public String IDCardNumberHash
        {
            get { return this._idCardNumberHash; }
            set { this._idCardNumberHash = value; }
        }

        /// <summary>
        /// 获取或设置性别
        /// </summary>
        [JsonProperty("sex")]
        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        /// <summary>
        /// 获取或设置民族
        /// </summary>
        [JsonProperty("nation")]
        public String Nation
        {
            get { return this._nation; }
            set { this._nation = value; }
        }

        /// <summary>
        /// 获取或设置单位代码
        /// </summary>
        [JsonProperty("organizationID")]
        public String OrganizationID
        {
            get { return this._organizationID; }
            set { this._organizationID = value; }
        }

        /// <summary>
        /// 获取或设置单位名称
        /// </summary>
        [JsonProperty("organizationName")]
        public String OrganizationName
        {
            get { return this._organizationName; }
            set { this._organizationName = value; }
        }
        #endregion
    }
}