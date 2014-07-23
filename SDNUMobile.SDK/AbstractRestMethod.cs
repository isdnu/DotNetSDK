using System;
using System.Collections.Generic;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 抽象调用方法
    /// </summary>
    public abstract class AbstractRestMethod
    {
        #region 字段
        private Dictionary<String, RequestParameter> _parameters;
        #endregion

        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        /// <remarks>
        /// 例如用户信息获取路径为：user/get
        /// </remarks>
        public abstract String MethodPath { get; }

        /// <summary>
        /// 获取返回实体类型
        /// </summary>
        public abstract Type ResultEntityType { get; }

        /// <summary>
        /// 获取所有参数集合
        /// </summary>
        public ICollection<RequestParameter> Parameters
        {
            get { return this._parameters.Values; }
        }
        #endregion

        #region 索引器
        /// <summary>
        /// 获取或设置指定参数名的参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>请求参数</returns>
        public RequestParameter this[String name]
        {
            get 
            {
                RequestParameter value = null;

                return this._parameters.TryGetValue(name, out value) ? value : null;
            }
            set { this._parameters[name] = value; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的抽象调用方法
        /// </summary>
        public AbstractRestMethod()
        {
            this._parameters = new Dictionary<String, RequestParameter>();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 尝试验证方法内参数
        /// </summary>
        /// <param name="error">错误信息（如果存在）</param>
        /// <returns>参数验证是否通过</returns>
        public virtual Boolean TryValidateParameters(out String error)
        {
            error = String.Empty;
            return true;
        }
        #endregion

        #region 保护方法
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>参数内容</returns>
        protected String GetParameterStringValue(String name)
        {
            RequestParameter param = null;

            if (!this._parameters.TryGetValue(name, out param))
            {
                return String.Empty;
            }

            if (param.ContentType == ParameterContentType.String)
            {
                return param.Value as String;
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>参数内容</returns>
        protected Int32? GetParameterInt32Value(String name)
        {
            RequestParameter param = null;

            if (!this._parameters.TryGetValue(name, out param))
            {
                return null;
            }

            if (param.ContentType == ParameterContentType.String)
            {
                return Convert.ToInt32(param.Value);
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>参数内容</returns>
        protected DateTime? GetParameterDateTimeValue(String name)
        {
            RequestParameter param = null;

            if (!this._parameters.TryGetValue(name, out param))
            {
                return null;
            }

            if (param.ContentType == ParameterContentType.String)
            {
                return DateTime.Parse(param.Value as String);
            }
            else
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>参数内容</returns>
        protected Byte[] GetParameterBinaryValue(String name)
        {
            RequestParameter param = null;

            if (!this._parameters.TryGetValue(name, out param))
            {
                return null;
            }

            if (param.ContentType == ParameterContentType.Binary)
            {
                return param.Value as Byte[];
            }
            else
            {
                throw new InvalidCastException(); 
            }
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        protected void SetParameter(String name, String value)
        {
            RequestParameter param = null;

            if (this._parameters.TryGetValue(name, out param))
            {
                param.SetParameterValue(value);
            }
            else
            {
                param = new RequestParameter(name, value);
                this._parameters[name] = param;
            }
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        protected void SetParameter<T>(String name, T value) where T : IFormattable
        {
            RequestParameter param = null;

            if (this._parameters.TryGetValue(name, out param))
            {
                param.SetParameterValue<T>(value);
            }
            else
            {
                param = new RequestParameter(name, value);
                this._parameters[name] = param;
            }
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        protected void SetParameter(String name, DateTime value)
        {
            RequestParameter param = null;

            if (this._parameters.TryGetValue(name, out param))
            {
                param.SetParameterValue(value);
            }
            else
            {
                param = new RequestParameter(name, value);
                this._parameters[name] = param;
            }
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="fileName">上传文件名</param>
        /// <param name="value">参数内容</param>
        protected void SetParameter(String name, String fileName, Byte[] value)
        {
            RequestParameter param = null;

            if (this._parameters.TryGetValue(name, out param))
            {
                param.SetParameterValue(fileName, value);
            }
            else
            {
                param = new RequestParameter(name, fileName, value);
                this._parameters[name] = param;
            }
        }
        #endregion
    }
}