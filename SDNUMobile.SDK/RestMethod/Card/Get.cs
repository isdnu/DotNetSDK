using System;

using SDNUMobile.SDK.Entity.Card;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Card
{
    /// <summary>
    /// 一卡通基本信息获取方法
    /// </summary>
    public class Get : AbstractRestMethod<CardInfo[]>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "card/get"; }
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