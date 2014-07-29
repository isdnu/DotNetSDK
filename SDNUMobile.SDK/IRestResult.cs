using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 请求结果实体
    /// </summary>
    public interface IRestResult
    {
        #region 属性
        /// <summary>
        /// 获取来源方法
        /// </summary>
        IRestMethod SourceMethod { get; }

        /// <summary>
        /// 获取执行是否成功
        /// </summary>
        Boolean Success { get; }

        /// <summary>
        /// 获取结果实体
        /// </summary>
        Object ResultObject { get; }

        /// <summary>
        /// 获取错误实体（如果存在）
        /// </summary>
        OAuthError Error { get; }
        #endregion
    }

    /// <summary>
    /// 泛型请求结果实体
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IRestResult<T> : IRestResult
    {
        #region 属性
        /// <summary>
        /// 获取结果实体
        /// </summary>
        T Result { get; }
        #endregion
    }
}