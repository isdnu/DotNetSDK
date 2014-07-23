using System;

namespace SDNUMobile.SDK.Entity.Bus
{
    /// <summary>
    /// 班车信息实体
    /// </summary>
    public class BusInfo
    {
        #region 字段
        private Int32 _routeOrder;
        private String _routeTitle;
        private String _routeStart;
        private Int32 _timeOrder;
        private String _timeTitle;
        private String _timeList;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置显示顺序
        /// </summary>
        public Int32 RouteOrder
        {
            get { return this._routeOrder; }
            set { this._routeOrder = value; }
        }

        /// <summary>
        /// 获取或设置路线名称
        /// </summary>
        public String RouteTitle
        {
            get { return this._routeTitle; }
            set { this._routeTitle = value; }
        }

        /// <summary>
        /// 获取或设置路线发车地点
        /// </summary>
        public String RouteStart
        {
            get { return this._routeStart; }
            set { this._routeStart = value; }
        }

        /// <summary>
        /// 获取或设置时间顺序
        /// </summary>
        public Int32 TimeOrder
        {
            get { return this._timeOrder; }
            set { this._timeOrder = value; }
        }

        /// <summary>
        /// 获取或设置时间名称
        /// </summary>
        public String TimeTitle
        {
            get { return this._timeTitle; }
            set { this._timeTitle = value; }
        }

        /// <summary>
        /// 获取或设置时间列表
        /// </summary>
        public String TimeList
        {
            get { return this._timeList; }
            set { this._timeList = value; }
        }
        #endregion
    }
}