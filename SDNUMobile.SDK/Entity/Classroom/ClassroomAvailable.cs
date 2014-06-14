using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.Entity.Classroom
{
    /// <summary>
    /// 可用教室信息实体
    /// </summary>
    public class ClassroomAvailable
    {
        #region 字段
        private Int32 _freetime;
        private ClassroomInfo[] _classrooms;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置连续空闲小节数
        /// </summary>
        [JsonProperty("freetime")]
        public Int32 Freetime
        {
            get { return this._freetime; }
            set { this._freetime = value; }
        }

        /// <summary>
        /// 获取或设置教室信息数组
        /// </summary>
        [JsonProperty("classrooms")]
        public ClassroomInfo[] Classrooms
        {
            get { return this._classrooms; }
            set { this._classrooms = value; }
        }
        #endregion
    }
}