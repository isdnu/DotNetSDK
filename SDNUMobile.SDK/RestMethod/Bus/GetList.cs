using System;
using System.Collections.Generic;

using SDNUMobile.SDK.Entity.Bus;

namespace SDNUMobile.SDK.RestMethod.Bus
{
    /// <summary>
    /// 班车信息获取方法
    /// </summary>
    public class GetList : AbstractRestMethod
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "bus/getlist"; }
        }

        /// <summary>
        /// 获取返回实体类型
        /// </summary>
        public override Type ResultEntityType
        {
            get { return typeof(Dictionary<String, BusInfo>); }
        }
        #endregion
    }
}