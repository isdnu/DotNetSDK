using System;

using SDNUMobile.SDK.Entity.People;

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
        #endregion
    }
}