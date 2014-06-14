using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Library
{
    /// <summary>
    /// 图书欠费信息实体
    /// </summary>
    public class LibraryArrearInfo
    {
        #region 字段
        private String _identityNumber;
        private String _bookName;
        private DateTime _recordDate;
        private Double _fineAmount;
        private DateTime? _dealDate;
        private Boolean _dealState;
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
        /// 获取或设置题名
        /// </summary>
        [JsonProperty("bookName")]
        public String BookName
        {
            get { return this._bookName; }
            set { this._bookName = value; }
        }

        /// <summary>
        /// 获取或设置记录日期
        /// </summary>
        [JsonProperty("recordDate")]
        public DateTime RecordDate
        {
            get { return this._recordDate; }
            set { this._recordDate = value; }
        }

        /// <summary>
        /// 获取或设置应罚金额
        /// </summary>
        [JsonProperty("fineAmount")]
        public Double FineAmount
        {
            get { return this._fineAmount; }
            set { this._fineAmount = value; }
        }

        /// <summary>
        /// 获取或设置处理日期
        /// </summary>
        [JsonProperty("dealDate")]
        public DateTime? DealDate
        {
            get { return this._dealDate; }
            set { this._dealDate = value; }
        }

        /// <summary>
        /// 获取或设置处理状态
        /// </summary>
        [JsonProperty("dealState")]
        public Boolean DealState
        {
            get { return this._dealState; }
            set { this._dealState = value; }
        }
        #endregion
    }
}