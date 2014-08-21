using System;

using SDNUMobile.SDK.Entity.Found;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Found
{
    /// <summary>
    /// 个人失物招领列表获取方法
    /// </summary>
    public class GetUserList : AbstractRestMethod<FoundSummary[]>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "found/getuserlist"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
        }

        /// <summary>
        /// 获取或设置失物招领类型
        /// </summary>
        public FoundObjectType? Type
        {
            get { return (FoundObjectType?)this.GetParameterByteValue("type"); }
            set { this.SetParameter("type", (Byte)value); }
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
        /// 初始化新的个人失物招领列表获取方法
        /// </summary>
        public GetUserList() { }

        /// <summary>
        /// 初始化新的个人失物招领列表获取方法
        /// </summary>
        /// <param name="type">失物招领类型</param>
        public GetUserList(FoundObjectType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// 初始化新的个人失物招领列表获取方法
        /// </summary>
        /// <param name="pageSize">获取数量</param>
        /// <param name="pageIndex">页面索引</param>
        public GetUserList(Int32 pageSize, Int32 pageIndex)
        {
            this.Count = pageSize;
            this.Index = pageIndex;
        }

        /// <summary>
        /// 初始化新的个人失物招领列表获取方法
        /// </summary>
        /// <param name="type">失物招领类型</param>
        /// <param name="pageSize">获取数量</param>
        /// <param name="pageIndex">页面索引</param>
        public GetUserList(FoundObjectType type, Int32 pageSize, Int32 pageIndex)
        {
            this.Type = type;
            this.Count = pageSize;
            this.Index = pageIndex;
        }
        #endregion
    }
}