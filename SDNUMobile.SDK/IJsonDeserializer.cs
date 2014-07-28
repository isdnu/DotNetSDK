using System;

namespace SDNUMobile.SDK
{
    /// <summary>
    /// Json反序列化接口
    /// </summary>
    public interface IJsonDeserializer
    {
        /// <summary>
        /// 将Json文本反序列化为实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="json">Json文本</param>
        /// <returns>反序列化后的实体</returns>
        T DeserializeJson<T>(String json);
    }
}