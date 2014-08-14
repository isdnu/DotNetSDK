using System;
using System.Collections.Generic;

using SDNUMobile.SDK.Entity.Bus;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Bus
{
    /// <summary>
    /// 班车信息获取方法
    /// </summary>
    public class GetList : AbstractRestMethod<Dictionary<String, BusInfo[]>>
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
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
        }
        #endregion
    }
}