using System;

using SDNUMobile.SDK.Entity.News;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.News
{
    /// <summary>
    /// 新闻信息获取方法
    /// </summary>
    public class Get : AbstractRestMethod<NewsDetail>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "news/get"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
        }

        /// <summary>
        /// 获取或设置站点ID
        /// </summary>
        public Int32 Site
        {
            get { return this.GetParameterInt32Value("site").Value; }
            set { this.SetParameter("site", value); }
        }
        
        /// <summary>
        /// 获取或设置新闻ID
        /// </summary>
        public Int32 NewsID
        {
            get { return this.GetParameterInt32Value("newsid").Value; }
            set { this.SetParameter("newsid", value); }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的新闻信息获取方法
        /// </summary>
        /// <param name="site">站点ID</param>
        /// <param name="newsID">新闻ID</param>
        public Get(Int32 site, Int32 newsID)
        {
            this.Site = site;
            this.NewsID = newsID;
        }
        #endregion
    }
}