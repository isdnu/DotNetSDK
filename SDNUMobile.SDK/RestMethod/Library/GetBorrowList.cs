﻿using System;

using SDNUMobile.SDK.Entity.Library;

namespace SDNUMobile.SDK.RestMethod.Library
{
    /// <summary>
    /// 图书馆借阅信息获取方法
    /// </summary>
    public class GetBorrowList : AbstractRestMethod<LibraryBorrowInfo[]>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "library/getborrowlist"; }
        }

        /// <summary>
        /// 获取或设置开始日期
        /// </summary>
        public DateTime? StartTime
        {
            get { return this.GetParameterDateTimeValue("start"); }
            set { this.SetParameter("start", value.Value); }
        }

        /// <summary>
        /// 获取或设置结束日期
        /// </summary>
        public DateTime? EndTime
        {
            get { return this.GetParameterDateTimeValue("end"); }
            set { this.SetParameter("end", value.Value); }
        }

        /// <summary>
        /// 获取或设置返回数量
        /// </summary>
        public Int32? Count
        {
            get { return this.GetParameterInt32Value("count"); }
            set { this.SetParameter("count", value.Value); }
        }

        /// <summary>
        /// 获取或设置返回页码
        /// </summary>
        public Int32? Index
        {
            get { return this.GetParameterInt32Value("index"); }
            set { this.SetParameter("index", value.Value); }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的图书馆借阅信息获取方法
        /// </summary>
        public GetBorrowList() { }

        /// <summary>
        /// 初始化新的图书馆借阅信息获取方法
        /// </summary>
        /// <param name="pageSize">获取数量</param>
        /// <param name="pageIndex">页面索引</param>
        public GetBorrowList(Int32 pageSize, Int32 pageIndex)
        {
            this.Count = pageSize;
            this.Index = pageIndex;
        }
        #endregion
    }
}