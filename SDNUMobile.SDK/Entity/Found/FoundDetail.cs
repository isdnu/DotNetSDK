using System;

namespace SDNUMobile.SDK.Entity.Found
{
    /// <summary>
    /// 失误招领详细信息实体
    /// </summary>
    public class FoundDetail
    {
        #region 字段
        private Int32 _foundID;
        private FoundObjectType _objectType;
        private String _objectDescription;
        private String _objectPictureUrl;
        private String _pickPlace;
        private DateTime? _pickTime;
        private String _pickContact;
        private Boolean _isHandedIn;
        private String _handedInPlace;
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
        /// 获取或设置物品照片Url
        /// </summary>
        public String ObjectPictureUrl
        {
            get { return this._objectPictureUrl; }
            set { this._objectPictureUrl = value; }
        }

        /// <summary>
        /// 获取或设置捡拾地点
        /// </summary>
        public String PickPlace
        {
            get { return this._pickPlace; }
            set { this._pickPlace = value; }
        }

        /// <summary>
        /// 获取或设置捡拾时间
        /// </summary>
        public DateTime? PickTime
        {
            get { return this._pickTime; }
            set { this._pickTime = value; }
        }

        /// <summary>
        /// 获取或设置捡拾联系人方式
        /// </summary>
        public String PickContact
        {
            get { return this._pickContact; }
            set { this._pickContact = value; }
        }

        /// <summary>
        /// 获取或设置是否上交
        /// </summary>
        public Boolean IsHandedIn
        {
            get { return this._isHandedIn; }
            set { this._isHandedIn = value; }
        }

        /// <summary>
        /// 获取或设置上交地点
        /// </summary>
        public String HandedInPlace
        {
            get { return this._handedInPlace; }
            set { this._handedInPlace = value; }
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