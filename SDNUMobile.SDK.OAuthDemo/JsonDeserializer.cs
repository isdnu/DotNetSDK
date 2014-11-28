using System;

using Newtonsoft.Json;

namespace SDNUMobile.SDK.OAuthDemo
{
    /// <summary>
    /// Json 反序列化器
    /// </summary>
    internal class JsonDeserializer : IJsonDeserializer
    {
        public static JsonDeserializer Instance = new JsonDeserializer();

        public T DeserializeJson<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}