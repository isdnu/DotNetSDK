using System;

namespace SDNUMobile.SDK.Entity.News
{
    /// <summary>
    /// 新闻详情实体
    /// </summary>
    public class NewsDetail
    {
        #region 字段
        private Int32 _newsID;
        private Int32 _categoryID;
        private String _title;
        private String _source;
        private String _author;
        private String _editor;
        private String _keywords;
        private String _content;
        private Int32 _showTimes;
        private NewsFile[] _files;
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
        /// 获取或设置新闻分类ID
        /// </summary>
        public Int32 CategoryID
        {
            get { return this._categoryID; }
            set { this._categoryID = value; }
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
        /// 获取或设置新闻来源
        /// </summary>
        public String Source
        {
            get { return this._source; }
            set { this._source = value; }
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
        /// 获取或设置新闻编辑
        /// </summary>
        public String Editor
        {
            get { return this._editor; }
            set { this._editor = value; }
        }

        /// <summary>
        /// 获取或设置新闻关键词
        /// </summary>
        public String Keywords
        {
            get { return this._keywords; }
            set { this._keywords = value; }
        }

        /// <summary>
        /// 获取或设置新闻内容
        /// </summary>
        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        /// <summary>
        /// 获取或设置新闻显示次数
        /// </summary>
        public Int32 ShowTimes
        {
            get { return this._showTimes; }
            set { this._showTimes = value; }
        }

        /// <summary>
        /// 获取或设置新闻相关文件
        /// </summary>
        public NewsFile[] AttachFiles
        {
            get { return this._files; }
            set { this._files = value; }
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