using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Bathroom
{
    /// <summary>
    /// 浴室使用用量统计实体
    /// </summary>
    public class BathroomUsageAmounts
    {
        #region 字段
        private BathroomInfo[] _bathrooms;
        private BathroomUsageAmount[] _usageAmounts;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置浴室信息
        /// </summary>
        [JsonProperty("bathrooms")]
        public BathroomInfo[] Bathrooms
        {
            get { return this._bathrooms; }
            set { this._bathrooms = value; }
        }

        /// <summary>
        /// 获取或设置浴室用量信息
        /// </summary>
        [JsonProperty("usageAmounts")]
        public BathroomUsageAmount[] UsageAmounts
        {
            get { return this._usageAmounts; }
            set { this._usageAmounts = value; }
        }
        #endregion
    }
}