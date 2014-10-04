using System;

namespace SDNUMobile.SDK.Entity.News
{
    /// <summary>
    /// 新闻摘要实体
    /// </summary>
    public class NewsSummary
    {
        #region 字段
        private Int32 _newsID;
        private String _title;
        private String _author;
        private DateTime _publishDate;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置新闻ID
        /// </summary>
        public Int32 NewsID
        {
            get { return this._newsID; }
            set { this._newsID = value; }
        }

        /// <summary>
        /// 获取或设置新闻标题
        /// </summary>
        public String Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        /// <summary>
        /// 获取或设置新闻作者
        /// </summary>
        public String Author
        {
            get { return this._author; }
            set { this._author = value; }
        }

        /// <summary>
        /// 获取或设置新闻发布时间
        /// </summary>
        public DateTime PublishDate
        {
            get { return this._publishDate; }
            set { this._publishDate = value; }
        }
        #endregion
    }
}