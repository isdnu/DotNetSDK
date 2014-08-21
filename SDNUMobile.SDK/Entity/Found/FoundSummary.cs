using System;

namespace SDNUMobile.SDK.Entity.Found
{
    /// <summary>
    /// 失误招领摘要信息实体
    /// </summary>
    public class FoundSummary
    {
        #region 字段
        private Int32 _foundID;
        private FoundObjectType _objectType;
        private String _objectDescription;
        private String _ownerName;
        private DateTime _submitTime;
        private Boolean _isOwnerRead;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置失误招领ID
        /// </summary>
        public Int32 FoundID
        {
            get { return this._foundID; }
            set { this._foundID = value; }
        }

        /// <summary>
        /// 获取或设置物品类型
        /// </summary>
        public FoundObjectType ObjectType
        {
            get { return this._objectType; }
            set { this._objectType = value; }
        }

        /// <summary>
        /// 获取或设置物品描述
        /// </summary>
        public String ObjectDescription
        {
            get { return this._objectDescription; }
            set { this._objectDescription = value; }
        }

        /// <summary>
        /// 获取或设置物品所有者姓名
        /// </summary>
        public String OwnerName
        {
            get { return this._ownerName; }
            set { this._ownerName = value; }
        }

        /// <summary>
        /// 获取或设置提交时间
        /// </summary>
        public DateTime SubmitTime
        {
            get { return this._submitTime; }
            set { this._submitTime = value; }
        }

        /// <summary>
        /// 获取或设置所有者是否已读
        /// </summary>
        public Boolean IsOwnerRead
        {
            get { return this._isOwnerRead; }
            set { this._isOwnerRead = value; }
        }
        #endregion
    }
}