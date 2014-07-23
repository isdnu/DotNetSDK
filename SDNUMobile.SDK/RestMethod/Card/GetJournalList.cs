using System;

using SDNUMobile.SDK.Entity.Card;

namespace SDNUMobile.SDK.RestMethod.Card
{
    /// <summary>
    /// 一卡通流水信息获取方法
    /// </summary>
    public class GetJournalList : AbstractRestMethod
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
        /// 获取返回实体类型
        /// </summary>
        public override Type ResultEntityType
        {
            get { return typeof(CardJournalInfo[]); }
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
        /// 初始化新的一卡通流水信息获取方法
        /// </summary>
        /// <param name="cardID">一卡通号</param>
        public GetJournalList(String cardID)
        {
            this.CardID = cardID;
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
