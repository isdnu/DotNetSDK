using System;

using SDNUMobile.SDK.Entity.News;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.News
{
    /// <summary>
    /// 新闻列表获取方法
    /// </summary>
    public class GetList : AbstractRestMethod<NewsSummary[]>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "news/getlist"; }
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
        /// 获取或设置站点分类ID
        /// </summary>
        public Int32 Category
        {
            get { return this.GetParameterInt32Value("category").Value; }
            set { this.SetParameter("category", value); }
        }

        /// <summary>
        /// 获取或设置返回页码
        /// </summary>
        public Int32? Index
        {
            get { return this.GetParameterInt32Value("index"); }
            set { this.SetParameter("index", value); }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的新闻列表获取方法
        /// </summary>
        /// <param name="site">站点ID</param>
        /// <param name="category">站点分类ID</param>
        public GetList(Int32 site, Int32 category)
        {
            this.Site = site;
            this.Category = category;
        }

        /// <summary>
        /// 初始化新的新闻列表获取方法
        /// </summary>
        /// <param name="site">站点ID</param>
        /// <param name="category">站点分类ID</param>
        /// <param name="pageIndex">页面索引</param>
        public GetList(Int32 site, Int32 category, Int32 pageIndex)
        {
            this.Site = site;
            this.Category = category;
            this.Index = pageIndex;
        }
        #endregion
    }
}