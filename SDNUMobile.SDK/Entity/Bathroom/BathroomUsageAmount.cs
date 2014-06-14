using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Bathroom
{
    /// <summary>
    /// 浴室使用用量实体
    /// </summary>
    public class BathroomUsageAmount
    {
        #region 字段
        private DateTime _logTime;
        private Int32[] _amount;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置记录时间
        /// </summary>
        [JsonProperty("logTime")]
        public DateTime LogTime
        {
            get { return this._logTime; }
            set { this._logTime = value; }
        }

        /// <summary>
        /// 获取或设置使用数量
        /// </summary>
        [JsonProperty("amount")]
        public Int32[] Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }
        #endregion
    }
}