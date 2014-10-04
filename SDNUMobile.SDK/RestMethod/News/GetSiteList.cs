using System;

using SDNUMobile.SDK.Entity.News;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.News
{
    /// <summary>
    /// 新闻站点信息获取方法
    /// </summary>
    public class GetSiteList : AbstractRestMethod<NewsSiteSummary[]>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "news/getsitelist"; }
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