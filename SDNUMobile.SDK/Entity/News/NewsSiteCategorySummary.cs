using System;

namespace SDNUMobile.SDK.Entity.News
{
    /// <summary>
    /// 新闻站点分类信息实体
    /// </summary>
    public class NewsSiteCategorySummary
    {
        #region 字段
        private Int32 _categoryID;
        private String _categoryName;
        private Int32 _categoryOrder;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置站点分类ID
        /// </summary>
        public Int32 CategoryID
        {
            get { return this._categoryID; }
            set { this._categoryID = value; }
        }

        /// <summary>
        /// 获取或设置站点分类名称
        /// </summary>
        public String CategoryName
        {
            get { return this._categoryName; }
            set { this._categoryName = value; }
        }

        /// <summary>
        /// 获取或设置站点分类显示顺序
        /// </summary>
        public Int32 CategoryOrder
        {
            get { return this._categoryOrder; }
            set { this._categoryOrder = value; }
        }
        #endregion
    }
}