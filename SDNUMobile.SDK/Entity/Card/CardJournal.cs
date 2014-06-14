using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Card
{
    /// <summary>
    /// 一卡通流水信息实体
    /// </summary>
    public class CardJournalInfo
    {
        #region 字段
        private String _cardID;
        private String _journalType;
        private String _commercialTenantName;
        private Double _tradingVolume;
        private Double _balance;
        private DateTime _tradingTime;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置一卡通卡号
        /// </summary>
        [JsonProperty("cardID")]
        public String CardID
        {
            get { return this._cardID; }
            set { this._cardID = value; }
        }

        /// <summary>
        /// 获取或设置交易类型
        /// </summary>
        [JsonProperty("journalType")]
        public String JournalType
        {
            get { return this._journalType; }
            set { this._journalType = value; }
        }

        /// <summary>
        /// 获取或设置商户名称
        /// </summary>
        [JsonProperty("commercialTenantName")]
        public String CommercialTenantName
        {
            get { return this._commercialTenantName; }
            set { this._commercialTenantName = value; }
        }

        /// <summary>
        /// 获取或设置交易额
        /// </summary>
        [JsonProperty("tradingVolume")]
        public Double TradingVolume
        {
            get { return this._tradingVolume; }
            set { this._tradingVolume = value; }
        }

        /// <summary>
        /// 获取或设置余额
        /// </summary>
        [JsonProperty("balance")]
        public Double Balance
        {
            get { return this._balance; }
            set { this._balance = value; }
        }

        /// <summary>
        /// 获取或设置交易时间
        /// </summary>
        [JsonProperty("tradingTime")]
        public DateTime TradingTime
        {
            get { return this._tradingTime; }
            set { this._tradingTime = value; }
        }
        #endregion
    }
}