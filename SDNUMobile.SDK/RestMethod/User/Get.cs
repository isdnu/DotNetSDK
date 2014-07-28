using System;

using SDNUMobile.SDK.Entity.User;

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
        #endregion
    }
}