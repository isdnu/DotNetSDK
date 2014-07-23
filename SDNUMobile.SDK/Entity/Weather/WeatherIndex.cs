using System;

namespace SDNUMobile.SDK.Entity.Weather
{
    /// <summary>
    /// 天气指数信息实体
    /// </summary>
    public class WeatherIndex
    {
        #region 字段
        private String _shortName;
        private String _chineseName;
        private String _chineseAliasName;
        private String _level;
        private String _content;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置指数简称
        /// </summary>
        public String ShortName
        {
            get { return this._shortName; }
            set { this._shortName = value; }
        }

        /// <summary>
        /// 获取或设置指数中文名称
        /// </summary>
        public String ChineseName
        {
            get { return this._chineseName; }
            set { this._chineseName = value; }
        }

        /// <summary>
        /// 获取或设置指数中文别名
        /// </summary>
        public String ChineseAliasName
        {
            get { return this._chineseAliasName; }
            set { this._chineseAliasName = value; }
        }

        /// <summary>
        /// 获取或设置指数级别
        /// </summary>
        public String Level
        {
            get { return this._level; }
            set { this._level = value; }
        }

        /// <summary>
        /// 获取或设置指数内容
        /// </summary>
        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }
        #endregion
    }
}