using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 参数内容类型
    /// </summary>
    public enum ParameterContentType : byte
    {
        String = 0,
        Binary = 1
    }

    /// <summary>
    /// 请求参数
    /// </summary>
    public class RequestParameter
    {
        #region 字段
        private String _name;
        private Object _value;
        private ParameterContentType _type;
        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置参数名
        /// </summary>
        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// 获取或设置参数内容
        /// </summary>
        public Object Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        /// <summary>
        /// 获取参数内容类型
        /// </summary>
        public ParameterContentType ContentType
        {
            get { return this._type; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        public RequestParameter(String name, String value)
        {
            this._name = name;
            this._value = value;
            this._type = ParameterContentType.String;
        }

        /// <summary>
        /// 初始化新的请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        public RequestParameter(String name, Int32 value)
            : this(name, value.ToString()) { }

        /// <summary>
        /// 初始化新的请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        public RequestParameter(String name, DateTime value)
            : this(name, value.ToString("yyyy-MM-dd HH:mm:ss")) { }

        /// <summary>
        /// 初始化新的请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        public RequestParameter(String name, Byte[] value)
        {
            this._name = name;
            this._value = value;
            this._type = ParameterContentType.Binary;
        }
        #endregion
    }
}