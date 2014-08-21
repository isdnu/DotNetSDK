using System;

using SDNUMobile.SDK.Entity.Found;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Found
{
    /// <summary>
    /// 失物招领详细信息获取方法
    /// </summary>
    public class Get : AbstractRestMethod<FoundDetail>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "found/get"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
        }

        /// <summary>
        /// 获取或设置返回页码
        /// </summary>
        public Int32 FoundID
        {
            get { return this.GetParameterInt32Value("foundid").Value; }
            set { this.SetParameter("foundid", value); }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的失物招领详细信息获取方法
        /// </summary>
        /// <param name="foundid">失物招领ID</param>
        public Get(Int32 foundid)
        {
            this.FoundID = foundid;
        }
        #endregion
    }
}