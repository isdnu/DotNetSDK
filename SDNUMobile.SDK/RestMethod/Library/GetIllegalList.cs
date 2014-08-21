using System;

using SDNUMobile.SDK.Entity.Library;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Library
{
    /// <summary>
    /// 图书馆违章信息获取方法
    /// </summary>
    public class GetIllegalList : AbstractRestMethod<LibraryIllegalInfo[]>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "library/getillegallist"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
        }

        /// <summary>
        /// 获取或设置开始日期
        /// </summary>
        public DateTime? StartTime
        {
            get { return this.GetParameterDateTimeValue("start"); }
            set { this.SetParameter("start", value); }
        }

        /// <summary>
        /// 获取或设置结束日期
        /// </summary>
        public DateTime? EndTime
        {
            get { return this.GetParameterDateTimeValue("end"); }
            set { this.SetParameter("end", value); }
        }

        /// <summary>
        /// 获取或设置返回数量
        /// </summary>
        public Int32? Count
        {
            get { return this.GetParameterInt32Value("count"); }
            set { this.SetParameter("count", value); }
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
        /// 初始化新的图书馆违章信息获取方法
        /// </summary>
        public GetIllegalList() { }

        /// <summary>
        /// 初始化新的图书馆违章信息获取方法
        /// </summary>
        /// <param name="pageSize">获取数量</param>
        /// <param name="pageIndex">页面索引</param>
        public GetIllegalList(Int32 pageSize, Int32 pageIndex)
        {
            this.Count = pageSize;
            this.Index = pageIndex;
        }
        #endregion
    }
}