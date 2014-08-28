using System;

namespace SDNUMobile.SDK.Entity.Power
{
    /// <summary>
    /// 电费摘要信息
    /// </summary>
    public class PowerSummary
    {
        #region 字段
        private Int32 _buildingNumber;
        private Int32 _roomNumber;
        private Double? _balance;
        private DateTime? _logDate;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置宿舍楼编号
        /// </summary>
        public Int32 BuildingNumber
        {
            get { return this._buildingNumber; }
            set { this._buildingNumber = value; }
        }

        /// <summary>
        /// 获取或设置宿舍编号
        /// </summary>
        public Int32 RoomNumber
        {
            get { return this._roomNumber; }
            set { this._roomNumber = value; }
        }

        /// <summary>
        /// 获取或设置剩余电量
        /// </summary>
        public Double? Balance
        {
            get { return this._balance; }
            set { this._balance = value; }
        }

        /// <summary>
        /// 获取或设置记录时间
        /// </summary>
        public DateTime? LogDate
        {
            get { return this._logDate; }
            set { this._logDate = value; }
        }
        #endregion
    }
}