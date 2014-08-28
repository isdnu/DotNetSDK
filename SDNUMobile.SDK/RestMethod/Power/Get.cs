using System;

using SDNUMobile.SDK.Entity;
using SDNUMobile.SDK.Entity.Power;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Power
{
    /// <summary>
    /// 电费基本信息获取方法
    /// </summary>
    public class Get : AbstractRestMethod<PowerSummary>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "power/get"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
        }

        /// <summary>
        /// 获取或设置校区类型
        /// </summary>
        public CampusType Campus
        {
            get { return (CampusType)this.GetParameterInt32Value("campus").Value; }
            set { this.SetParameter("campus", (Byte)value); }
        }

        /// <summary>
        /// 获取或设置宿舍楼编号
        /// </summary>
        public Int32 BuildingNumber
        {
            get { return this.GetParameterInt32Value("building").Value; }
            set { this.SetParameter("building", value); }
        }

        /// <summary>
        /// 获取或设置宿舍编号
        /// </summary>
        public Int32 RoomNumber
        {
            get { return this.GetParameterInt32Value("room").Value; }
            set { this.SetParameter("room", value); }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的电费基本信息获取方法
        /// </summary>
        /// <param name="campus">校区类型</param>
        /// <param name="buildingNumber">宿舍楼编号</param>
        /// <param name="roomNumber">宿舍编号</param>
        public Get(CampusType campus, Int32 buildingNumber, Int32 roomNumber)
        {
            this.Campus = campus;
            this.BuildingNumber = buildingNumber;
            this.RoomNumber = roomNumber;
        }
        #endregion
    }
}