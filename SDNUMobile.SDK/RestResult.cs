using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 请求结果类
    /// </summary>
    public class RestResult
    {
        #region 字段
        private IRestMethod _sourceMethod;
        private Object _result;
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
        /// 获取结果实体
        /// </summary>
        public Object Result
        {
            get { return this._result; }
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
        public RestResult(IRestMethod source, Object result)
        {
            this._sourceMethod = source;
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
            this._result = null;
            this._error = error;
        }
        #endregion
    }
}