智慧山师 DotNetSDK
=========

服务接口调用示例代码
---------

    using System;
    using System.Threading;
    
    using Newtonsoft.Json;
    
    using SDNUMobile.SDK.Entity.Poi;
    
    class JsonDeserializer : IJsonDeserializer
    {
        public static JsonDeserializer Instance = new JsonDeserializer();

        public Object DeserializeJson(String json, Type entityType)
        {
            return JsonConvert.DeserializeObject(json, entityType);
        }
    }
    
    class Program
    {
        static ManualResetEvent allDone = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            String consumerKey = "test_consumer_key_00000000000001";
            String consumerSecret = "test_consumer_secrettest_consumer_secret";

            IClient client = new XAuthClient(JsonDeserializer.Instance, consumerKey, consumerSecret);

            client.RequestRestMethodAsync(new RestMethod.Poi.GetList(), new Action<RestResult>((RestResult result) =>
            {
                if (result.Error != null)
                {
                    Console.WriteLine(result.Error.ErrorDescription);
                    allDone.Set();
                    return;
                }

                SchoolPosition[] positions = result.Result as SchoolPosition[];

                foreach (SchoolPosition pos in positions)
                {
                    Console.WriteLine(String.Format("{0}:{1},{2}", pos.PositionName, pos.Longitude, pos.Latitude));
                }

                allDone.Set();
            }));

            allDone.WaitOne();
        }
    }

相关链接
---------
智慧山师 http://i.sdnu.edu.cn 

智慧山师开放平台 http://i.sdnu.edu.cn/open 

人人网公共主页 http://page.renren.com/601879820 

新浪微博 http://weibo.com/smartsdnu 
