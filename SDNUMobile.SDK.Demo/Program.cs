using System;
using System.Threading;

using Newtonsoft.Json;

using SDNUMobile.SDK.Entity.People;
using SDNUMobile.SDK.Entity.Poi;

namespace SDNUMobile.SDK.Demo
{
    class JsonDeserializer : IJsonDeserializer
    {
        public static JsonDeserializer Instance = new JsonDeserializer();

        public T DeserializeJson<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

    class Program
    {
        static ManualResetEvent allDone = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            String consumerKey = "test_consumer_key_00000000000001";
            String consumerSecret = "test_consumer_secrettest_consumer_secret";

            String userName = "username";
            String passWord = "password";

            XAuthClient client = new XAuthClient(JsonDeserializer.Instance, consumerKey, consumerSecret);

            RequestPublicData(client);//获取公共数据
            allDone.WaitOne();
            allDone.Reset();

            RequestAccessTokenByXAuth(userName, passWord, client);//XAuth登陆
            allDone.WaitOne();
            allDone.Reset();

            RequestPrivateData(client);//获取个人数据
            allDone.WaitOne();
        }

        static void RequestPublicData(IClient client)
        {
            client.RequestRestMethodAsync(new RestMethod.Poi.GetList(), result =>
            {
                if (result.Error != null)
                {
                    Console.WriteLine(result.Error.ErrorDescription);
                }
                else
                {
                    SchoolPosition[] positions = result.Result;

                    foreach (SchoolPosition pos in positions)
                    {
                        Console.WriteLine(String.Format("{0}:{1},{2}", 
                            pos.PositionName, pos.Longitude, pos.Latitude));
                    }
                }

                allDone.Set();
            });
        }

        static void RequestAccessTokenByXAuth(String userName, String passWord, XAuthClient client)
        {
            client.RequestAccessTokenAsync(userName, passWord, result =>
            {
                if (result.Error != null)
                {
                    Console.WriteLine(result.Error.ErrorDescription);
                }
                else
                {
                    Console.WriteLine(String.Format("Token ID:{0}", result.Token.TokenID));
                }

                allDone.Set();
            });
        }

        static void RequestPrivateData(IClient client)
        {
            client.RequestRestMethodAsync(new RestMethod.People.Get(), result =>
            {
                if (result.Error != null)
                {
                    Console.WriteLine(result.Error.ErrorDescription);
                }
                else
                {
                    PeopleInfo people = result.Result;
                    Console.WriteLine(String.Format("{0}({1}):{2}", 
                        people.Name, people.IdentityNumber, people.OrganizationName));
                }

                allDone.Set();
            });
        }
    }
}