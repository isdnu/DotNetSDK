using System;

using SDNUMobile.SDK.Entity.User;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.User
{
    /// <summary>
    /// 用户信息获取方法
    /// </summary>
    public class Get : AbstractRestMethod<UserInfo>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "user/get"; }
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