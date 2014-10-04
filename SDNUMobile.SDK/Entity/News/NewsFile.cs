using System;

namespace SDNUMobile.SDK.Entity.News
{
    /// <summary>
    /// 新闻文件实体
    /// </summary>
    public class NewsFile
    {
        #region 字段
        private String _reference;
        private String _sourceUrl;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置文件引用名称
        /// </summary>
        public String Reference
        {
            get { return this._reference; }
            set { this._reference = value; }
        }

        /// <summary>
        /// 获取或设置文件地址
        /// </summary>
        public String SourceUrl
        {
            get { return this._sourceUrl; }
            set { this._sourceUrl = value; }
        }
        #endregion
    }
}