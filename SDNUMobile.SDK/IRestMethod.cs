using System;
using System.Collections.Generic;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// 调用方法接口
    /// </summary>
    public interface IRestMethod
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        /// <remarks>
        /// 例如用户信息获取路径为：user/get
        /// </remarks>
        String MethodPath { get; }

        /// <summary>
        /// 获取返回实体类型
        /// </summary>
        Type ResultEntityType { get; }

        /// <summary>
        /// 获取所有参数集合
        /// </summary>
        ICollection<RequestParameter> Parameters { get; }
        #endregion

        #region 索引器
        /// <summary>
        /// 获取或设置指定参数名的参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>请求参数</returns>
        RequestParameter this[String name] { get; set; }
        #endregion

        #region 方法
        /// <summary>
        /// 尝试验证方法内参数
        /// </summary>
        /// <param name="error">错误信息（如果存在）</param>
        /// <returns>参数验证是否通过</returns>
        Boolean TryValidateParameters(out String error);
        #endregion
    }

    /// <summary>
    /// 泛型调用方法接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IRestMethod<T> : IRestMethod { }
}