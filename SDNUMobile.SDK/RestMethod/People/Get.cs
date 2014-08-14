using System;

using SDNUMobile.SDK.Entity.People;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.People
{
    /// <summary>
    /// 人员信息获取方法
    /// </summary>
    public class Get : AbstractRestMethod<PeopleInfo>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "people/get"; }
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