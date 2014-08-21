using System;

using SDNUMobile.SDK.Entity.Found;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Found
{
    /// <summary>
    /// 一卡通失物招领添加方法
    /// </summary>
    public class AddCardFound : AbstractRestMethod<FoundDetail>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "found/addcardfound"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Post; }
        }

        /// <summary>
        /// 获取或设置捡拾地点
        /// </summary>
        public String PickPlace
        {
            get { return this.GetParameterStringValue("pickplace"); }
            set { this.SetParameter("pickplace", value); }
        }

        /// <summary>
        /// 获取或设置捡拾时间
        /// </summary>
        public DateTime? PickTime
        {
            get { return this.GetParameterDateTimeValue("picktime"); }
            set { this.SetParameter("picktime", value); }
        }

        /// <summary>
        /// 获取或设置捡拾地点
        /// </summary>
        public String PickContact
        {
            get { return this.GetParameterStringValue("pickcontact"); }
            set { this.SetParameter("pickcontact", value); }
        }

        /// <summary>
        /// 获取或设置是否已上交
        /// </summary>
        public Boolean IsHandedIn
        {
            get { return this.GetParameterBooleanValue("ishandedin").Value; }
            set { this.SetParameter("ishandedin", value); }
        }

        /// <summary>
        /// 获取或设置上交地点
        /// </summary>
        public String HandedInPlace
        {
            get { return this.GetParameterStringValue("handedinplace"); }
            set { this.SetParameter("handedinplace", value); }
        }

        /// <summary>
        /// 获取或设置一卡通所有者学工号
        /// </summary>
        public String OwnerUserID
        {
            get { return this.GetParameterStringValue("owneruserid"); }
            set { this.SetParameter("owneruserid", value); }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的一卡通失物招领添加方法
        /// </summary>
        /// <param name="ownerUserID">一卡通所有者学工号</param>
        /// <param name="isHandedIn">是否上交</param>
        public AddCardFound(String ownerUserID, Boolean isHandedIn)
        {
            this.OwnerUserID = ownerUserID;
            this.IsHandedIn = isHandedIn;
        }
        #endregion
    }
}