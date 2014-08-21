using System;

using SDNUMobile.SDK.Entity.Card;
using SDNUMobile.SDK.Net;

namespace SDNUMobile.SDK.RestMethod.Card
{
    /// <summary>
    /// 一卡通流水信息获取方法
    /// </summary>
    public class GetJournalList : AbstractRestMethod<CardJournalInfo[]>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "card/getjournallist"; }
        }

        /// <summary>
        /// 获取方法请求类型
        /// </summary>
        public override RequestMethod RequestMethod
        {
            get { return RequestMethod.Get; }
        }

        /// <summary>
        /// 获取或设置一卡通ID
        /// </summary>
        public String CardID
        {
            get { return this.GetParameterStringValue("cardid"); }
            set { this.SetParameter("cardid", value); }
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
        /// 初始化新的一卡通流水信息获取方法
        /// </summary>
        /// <param name="cardID">一卡通号</param>
        public GetJournalList(String cardID)
        {
            this.CardID = cardID;
        }

        /// <summary>
        /// 初始化新的一卡通流水信息获取方法
        /// </summary>
        /// <param name="cardID">一卡通号</param>
        /// <param name="pageSize">获取数量</param>
        /// <param name="pageIndex">页面索引</param>
        public GetJournalList(String cardID, Int32 pageSize, Int32 pageIndex)
        {
            this.CardID = cardID;
            this.Count = pageSize;
            this.Index = pageIndex;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 尝试验证方法内参数
        /// </summary>
        /// <param name="error">错误信息（如果存在）</param>
        /// <returns>参数验证是否通过</returns>
        public override Boolean TryValidateParameters(out String error)
        {
            if (String.IsNullOrEmpty(this.CardID))
            {
                error = "一卡通号不能为空！";
                return false;
            }

            error = String.Empty;
            return true;
        }
        #endregion
    }
}
