using System;

namespace SDNUMobile.SDK.Entity.Card
{
    /// <summary>
    /// 一卡通基本信息实体
    /// </summary>
    public class CardInfo
    {
        #region 字段
        private String _identityNumber;
        private String _name;
        private Int64 _cardID;
        private String _cardTypeName;
        private Double _balance;
        private Boolean _lossState;
        private Boolean _freezeState;
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
        /// 获取或设置姓名
        /// </summary>
        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// 获取或设置一卡通卡号
        /// </summary>
        public Int64 CardID
        {
            get { return this._cardID; }
            set { this._cardID = value; }
        }

        /// <summary>
        /// 获取或设置卡类型名称
        /// </summary>
        public String CardTypeName
        {
            get { return this._cardTypeName; }
            set { this._cardTypeName = value; }
        }

        /// <summary>
        /// 获取或设置余额
        /// </summary>
        public Double Balance
        {
            get { return this._balance; }
            set { this._balance = value; }
        }

        /// <summary>
        /// 获取或设置挂失状态
        /// </summary>
        public Boolean LossState
        {
            get { return this._lossState; }
            set { this._lossState = value; }
        }

        /// <summary>
        /// 获取或设置冻结状态
        /// </summary>
        public Boolean FreezeState
        {
            get { return this._freezeState; }
            set { this._freezeState = value; }
        }
        #endregion
    }
}