using System;
using System.Collections.Generic;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 请求参数比较器
    /// </summary>
    public class RequestParameterComparer : Comparer<RequestParameter>
    {
        #region 静态字段
        private static RequestParameterComparer _default;
        #endregion

        #region 静态属性
        /// <summary>
        /// 获取默认请求参数比较器
        /// </summary>
        public new static RequestParameterComparer Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new RequestParameterComparer();
                }

                return _default;
            }
        }
        #endregion

        #region 字段
        private IComparer<String> _baseComparer;
        #endregion

        #region 构造方法
        /// <summary>
        /// 初始化新的请求参数比较器
        /// </summary>
        public RequestParameterComparer()
        {
            this._baseComparer = Comparer<String>.Default;
        }
        #endregion

        #region 方法
        public override Int32 Compare(RequestParameter x, RequestParameter y)
        {
            return this._baseComparer.Compare(x.Name, y.Name);
        }
        #endregion
    }
}