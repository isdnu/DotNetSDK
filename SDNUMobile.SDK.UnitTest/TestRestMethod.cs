using System;

namespace SDNUMobile.SDK.UnitTest
{
    internal class TestRestMethod : AbstractRestMethod<String>
    {
        #region 属性
        /// <summary>
        /// 获取方法路径
        /// </summary>
        public override String MethodPath
        {
            get { return "test"; }
        }
        #endregion

        #region 开放保护方法
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>参数内容</returns>
        internal String InternalGetParameterStringValue(String name)
        {
            return this.GetParameterStringValue(name);
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>参数内容</returns>
        internal Int32? InternalGetParameterInt32Value(String name)
        {
            return this.GetParameterInt32Value(name);
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>参数内容</returns>
        internal DateTime? InternalGetParameterDateTimeValue(String name)
        {
            return this.GetParameterDateTimeValue(name);
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>参数内容</returns>
        internal Byte[] InternalGetParameterBinaryValue(String name)
        {
            return this.GetParameterBinaryValue(name);
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        internal void InternalSetParameter(String name, String value)
        {
            this.SetParameter(name, value);
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        internal void InternalSetParameter<T>(String name, T value) where T : IFormattable
        {
            this.SetParameter<T>(name, value);
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数内容</param>
        internal void InternalSetParameter(String name, DateTime value)
        {
            this.SetParameter(name, value);
        }

        /// <summary>
        /// 设置请求参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="fileName">上传文件名</param>
        /// <param name="value">参数内容</param>
        internal void InternalSetParameter(String name, String fileName, Byte[] value)
        {
            this.SetParameter(name, fileName, value);
        }
        #endregion
    }
}