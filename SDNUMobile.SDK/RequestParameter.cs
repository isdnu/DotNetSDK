using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 参数内容类型
    /// </summary>
    public enum ParameterContentType : byte
    {
        /// <summary>
        /// 字符串类型
        /// </summary>
        String = 0,

        /// <summary>
        /// 二进制类型
        /// </summary>
        Binary = 1
    }

    /// <summary>
    /// 请求参数
    /// </summary>
    public class RequestParameter
    {
        #region 常量
        private const String DateTimeStringFormat = "yyyy-MM-dd HH:mm:ss";
        #endregion

        #region 字段
        private String _name;
        private String _fileName;
        private Object _value;
        private ParameterContentType _type;
        #endregion

        #region 属性
        /// <summary>
        /// 获取参数名
        /// </summary>
        public String Name
        {
            get { return this._name; }
        }

        /// <summary>
        /// 获取上传文件名
        /// </summary>
        internal String FileName
        {
            get { return this._fileName; }
        }

        /// <summary>
        /// 获取参数内容
        /// </summary>
        public Object Value
        {
            get { return this._value; }
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
        public RequestParameter(String name, IFormattable value)
            : this(name, value.ToString()) { }

        /// <summary>
        /// 初始化新的请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        public RequestParameter(String name, Boolean value)
            : this(name, value.ToString().ToLowerInvariant()) { }

        /// <summary>
        /// 初始化新的请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        public RequestParameter(String name, DateTime value)
            : this(name, value.ToString(DateTimeStringFormat)) { }

        /// <summary>
        /// 初始化新的请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="fileName">上传文件名</param>
        /// <param name="value">参数内容</param>
        public RequestParameter(String name, String fileName, Byte[] value)
        {
            this._name = name;
            this._fileName = fileName;
            this._value = value;
            this._type = ParameterContentType.Binary;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 设置参数内容
        /// </summary>
        /// <param name="value">参数内容</param>
        public void SetParameterValue(String value)
        {
            this._value = value;
            this._type = ParameterContentType.String;
        }

        /// <summary>
        /// 设置参数内容
        /// </summary>
        /// <param name="value">参数内容</param>
        public void SetParameterValue<T>(T value) where T : IFormattable
        {
            this.SetParameterValue(value.ToString());
        }

        /// <summary>
        /// 设置参数内容
        /// </summary>
        /// <param name="value">参数内容</param>
        public void SetParameterValue(Boolean value)
        {
            this.SetParameterValue(value.ToString().ToLowerInvariant());
        }

        /// <summary>
        /// 设置参数内容
        /// </summary>
        /// <param name="value">参数内容</param>
        public void SetParameterValue(DateTime value)
        {
            this.SetParameterValue(value.ToString(DateTimeStringFormat));
        }

        /// <summary>
        /// 设置参数内容
        /// </summary>
        /// <param name="fileName">上传文件名</param>
        /// <param name="value">参数内容</param>
        public void SetParameterValue(String fileName, Byte[] value)
        {
            this._fileName = fileName;
            this._value = value;
            this._type = ParameterContentType.Binary;
        }
        #endregion
    }
}