using System;

namespace SDNUMobile.SDK.Entity.Classroom
{
    /// <summary>
    /// 教室信息实体
    /// </summary>
    public class ClassroomInfo
    {
        #region 字段
        private String _classroomName;
        private String _classRoomBuilding;
        private CampusType _campusType;
        private String _mondayCourse;
        private String _tuesdayCourse;
        private String _wednesdayCourse;
        private String _thursdayCourse;
        private String _fridayCourse;
        private String _saturdayCourse;
        private String _sundayCourse;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置教室名称
        /// </summary>
        public String ClassroomName
        {
            get { return this._classroomName; }
            set { this._classroomName = value; }
        }

        /// <summary>
        /// 获取或设置教室教学楼
        /// </summary>
        public String ClassRoomBuilding
        {
            get { return this._classRoomBuilding; }
            set { this._classRoomBuilding = value; }
        }

        /// <summary>
        /// 获取或设置校区类型
        /// </summary>
        public CampusType CampusType
        {
            get { return this._campusType; }
            set { this._campusType = value; }
        }

        /// <summary>
        /// 获取或设置周一课程
        /// </summary>
        public String MondayCourse
        {
            get { return this._mondayCourse; }
            set { this._mondayCourse = value; }
        }

        /// <summary>
        /// 获取或设置周二课程
        /// </summary>
        public String TuesdayCourse
        {
            get { return this._tuesdayCourse; }
            set { this._tuesdayCourse = value; }
        }

        /// <summary>
        /// 获取或设置周三课程
        /// </summary>
        public String WednesdayCourse
        {
            get { return this._wednesdayCourse; }
            set { this._wednesdayCourse = value; }
        }

        /// <summary>
        /// 获取或设置周四课程
        /// </summary>
        public String ThursdayCourse
        {
            get { return this._thursdayCourse; }
            set { this._thursdayCourse = value; }
        }

        /// <summary>
        /// 获取或设置周五课程
        /// </summary>
        public String FridayCourse
        {
            get { return this._fridayCourse; }
            set { this._fridayCourse = value; }
        }

        /// <summary>
        /// 获取或设置周六课程
        /// </summary>
        public String SaturdayCourse
        {
            get { return this._saturdayCourse; }
            set { this._saturdayCourse = value; }
        }

        /// <summary>
        /// 获取或设置周日课程
        /// </summary>
        public String SundayCourse
        {
            get { return this._sundayCourse; }
            set { this._sundayCourse = value; }
        }
        #endregion
    }
}
