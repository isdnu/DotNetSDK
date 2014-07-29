using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 请求结果类
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class RestResult<T> : IRestResult<T>, IRestResult
    {
        #region 字段
        private IRestMethod _sourceMethod;
        private Boolean _success;
        private T _result;
        private OAuthError _error;
        #endregion

        #region 属性
        /// <summary>
        /// 获取来源方法
        /// </summary>
        public IRestMethod SourceMethod
        {
            get { return this._sourceMethod; }
        }

        /// <summary>
        /// 获取执行是否成功
        /// </summary>
        public Boolean Success
        {
            get { return this._success; }
        }

        /// <summary>
        /// 获取结果实体
        /// </summary>
        public T Result
        {
            get { return this._result; }
        }

        /// <summary>
        /// 获取结果实体
        /// </summary>
        Object IRestResult.ResultObject
        {
            get { return (Object)this._result; }
        }

        /// <summary>
        /// 获取错误实体（如果存在）
        /// </summary>
        public OAuthError Error
        {
            get { return this._error; }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的请求结果类
        /// </summary>
        /// <param name="source">来源方法</param>
        /// <param name="result">结果实体</param>
        public RestResult(IRestMethod source, T result)
        {
            this._sourceMethod = source;
            this._success = true;
            this._result = result;
            this._error = null;
        }

        /// <summary>
        /// 初始化新的请求结果类
        /// </summary>
        /// <param name="source">来源方法</param>
        /// <param name="error">错误实体</param>
        public RestResult(IRestMethod source, OAuthError error)
        {
            this._sourceMethod = source;
            this._success = false;
            this._result = default(T);
            this._error = error;
        }
        #endregion
    }
}