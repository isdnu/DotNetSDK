using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Library
{
    /// <summary>
    /// 图书违章信息实体
    /// </summary>
    public class LibraryIllegalInfo
    {
        #region 字段
        private String _identityNumber;
        private String _illegalTypeName;
        private DateTime? _cannotBorrowEndDate;
        private Double _realFineAmount;
        private DateTime _illegalDate;
        private Byte _dealStateCode;
        private String _dealState;
        private String _dealExplanation;
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
        /// 获取或设置违章类型名称
        /// </summary>
        [JsonProperty("illegalTypeName")]
        public String IllegalTypeName
        {
            get { return this._illegalTypeName; }
            set { this._illegalTypeName = value; }
        }

        /// <summary>
        /// 获取或设置违章停借截止日期
        /// </summary>
        [JsonProperty("cannotBorrowEndDate")]
        public DateTime? CannotBorrowEndDate
        {
            get { return this._cannotBorrowEndDate; }
            set { this._cannotBorrowEndDate = value; }
        }

        /// <summary>
        /// 获取或设置实罚款额 
        /// </summary>
        [JsonProperty("realFineAmount")]
        public Double RealFineAmount
        {
            get { return this._realFineAmount; }
            set { this._realFineAmount = value; }
        }

        /// <summary>
        /// 获取或设置违章时间
        /// </summary>
        [JsonProperty("illegalDate")]
        public DateTime IllegalDate
        {
            get { return this._illegalDate; }
            set { this._illegalDate = value; }
        }

        /// <summary>
        /// 获取或设置违章处理状态代码
        /// </summary>
        [JsonProperty("dealStateCode")]
        public Byte DealStateCode
        {
            get { return this._dealStateCode; }
            set { this._dealStateCode = value; }
        }

        /// <summary>
        /// 获取或设置违章处理状态
        /// </summary>
        [JsonProperty("dealState")]
        public String DealState
        {
            get { return this._dealState; }
            set { this._dealState = value; }
        }

        /// <summary>
        /// 获取或设置违章说明
        /// </summary>
        [JsonProperty("dealExplanation")]
        public String DealExplanation
        {
            get { return this._dealExplanation; }
            set { this._dealExplanation = value; }
        }
        #endregion
    }
}