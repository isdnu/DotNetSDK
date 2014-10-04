using System;

namespace SDNUMobile.SDK.Entity.News
{
    /// <summary>
    /// 新闻站点信息实体
    /// </summary>
    public class NewsSiteSummary
    {
        #region 字段
        private Int32 _siteID;
        private String _siteName;
        private String _siteUrl;
        private Int32 _siteOrder;
        private NewsSiteCategorySummary[] _categorys;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置站点ID
        /// </summary>
        public Int32 SiteID
        {
            get { return this._siteID; }
            set { this._siteID = value; }
        }

        /// <summary>
        /// 获取或设置站点名称
        /// </summary>
        public String SiteName
        {
            get { return this._siteName; }
            set { this._siteName = value; }
        }

        /// <summary>
        /// 获取或设置站点Url
        /// </summary>
        public String SiteUrl
        {
            get { return this._siteUrl; }
            set { this._siteUrl = value; }
        }

        /// <summary>
        /// 获取或设置站点显示顺序
        /// </summary>
        public Int32 SiteOrder
        {
            get { return this._siteOrder; }
            set { this._siteOrder = value; }
        }

        /// <summary>
        /// 获取或设置站点分类列表
        /// </summary>
        public NewsSiteCategorySummary[] Categorys
        {
            get { return this._categorys; }
            set { this._categorys = value; }
        }
        #endregion
    }
}