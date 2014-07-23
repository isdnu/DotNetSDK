DotNetSDK
=========

DotNet SDK for i.sdnu.edu.cn 智慧山师

示例代码
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
