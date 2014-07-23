using System;

namespace SDNUMobile.SDK.Entity.Library
{
    /// <summary>
    /// 图书借阅信息实体
    /// </summary>
    public class LibraryBorrowInfo
    {
        #region 字段
        private String _identityNumber;
        private String _bookName;
        private DateTime _borrowDate;
        private DateTime _mustReturnDate;
        private Boolean _isRenew;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置身份认证号
        /// </summary>
        public String IdentityNumber
        {
            get { return this._identityNumber; }
            set { this._identityNumber = value; }
        }

        /// <summary>
        /// 获取或设置图书题名
        /// </summary>
        public String BookName
        {
            get { return this._bookName; }
            set { this._bookName = value; }
        }

        /// <summary>
        /// 获取或设置借书日期
        /// </summary>
        public DateTime BorrowDate
        {
            get { return this._borrowDate; }
            set { this._borrowDate = value; }
        }

        /// <summary>
        /// 获取或设置应还日期
        /// </summary>
        public DateTime MustReturnDate
        {
            get { return this._mustReturnDate; }
            set { this._mustReturnDate = value; }
        }

        /// <summary>
        /// 获取或设置续借标志
        /// </summary>
        public Boolean IsRenew
        {
            get { return this._isRenew; }
            set { this._isRenew = value; }
        }
        #endregion
    }
}