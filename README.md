智慧山师 DotNetSDK
=========

OAuth1.0a授权和服务接口调用示例
---------
    using System;
    using System.Threading;

    using Newtonsoft.Json;

    using SDNUMobile.SDK;
    using SDNUMobile.SDK.Entity.People;

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
        static RequestToken requestToken;

        static void Main(string[] args)
        {
            String consumerKey = "test_consumer_key_00000000000001";
            String consumerSecret = "test_consumer_secrettest_consumer_secret";

            OAuthClient client = new OAuthClient(JsonDeserializer.Instance, consumerKey, consumerSecret);

            RequestRequestTokenByOAuth(client);//获取请求令牌
            allDone.WaitOne();
            allDone.Reset();

            String authorizeUrl = client.GetAuthorizeUrl(requestToken);//引导用户访问该地址，登录并授权
            Console.WriteLine(authorizeUrl);

            String callbackUrl = Console.ReadLine();//从回调地址中获取验证码
            String verifier = client.GetVerifierFromCallbackUrl(callbackUrl);

            RequestAccessTokenByOAuth(client, requestToken, verifier);
            allDone.WaitOne();
            allDone.Reset();

            RequestPrivateData(client);//获取个人数据
            allDone.WaitOne();
        }

        static void RequestRequestTokenByOAuth(OAuthClient client)
        {
            client.RequestRequestTokenAsync(new Action<TokenResult>((TokenResult result) =>
            {
                requestToken = result.Token as RequestToken;

                allDone.Set();
            }));
        }

        static void RequestAccessTokenByOAuth(OAuthClient client, RequestToken token, String verifier)
        {
            client.RequestAccessTokenAsync(token, verifier, new Action<TokenResult>((TokenResult result) =>
            {
                if (result.Success)
                {
                    Console.WriteLine(String.Format("Token ID:{0}", result.Token.TokenID));
                }

                allDone.Set();
            }));
        }

        static void RequestPrivateData(IClient client)
        {
            client.RequestRestMethodAsync(new SDNUMobile.SDK.RestMethod.People.Get(), new Action<RestResult>((RestResult result) =>
            {
                if (result.Success)
                {
                    PeopleInfo people = result.Result as PeopleInfo;
                    Console.WriteLine(String.Format("{0}({1}):{2}", people.Name, people.IdentityNumber, people.OrganizationName));
                }

                allDone.Set();
            }));
        }
    }


XAuth授权和服务接口调用示例
---------

    using System;
    using System.Threading;

    using Newtonsoft.Json;

    using SDNUMobile.SDK;
    using SDNUMobile.SDK.Entity.People;

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

            String userName = "username";
            String passWord = "password";

            XAuthClient client = new XAuthClient(JsonDeserializer.Instance, consumerKey, consumerSecret);

            RequestAccessTokenByXAuth(userName, passWord, client);//XAuth登陆
            allDone.WaitOne();
            allDone.Reset();

            RequestPrivateData(client);//获取个人数据
            allDone.WaitOne();
        }

        static void RequestAccessTokenByXAuth(String userName, String passWord, XAuthClient client)
        {
            client.RequestAccessTokenAsync(userName, passWord, new Action<TokenResult>((TokenResult result) =>
            {
                if (result.Success)
                {
                    Console.WriteLine(String.Format("Token ID:{0}", result.Token.TokenID));
                }

                allDone.Set();
            }));
        }

        static void RequestPrivateData(IClient client)
        {
            client.RequestRestMethodAsync(new SDNUMobile.SDK.RestMethod.People.Get(), new Action<RestResult>((RestResult result) =>
            {
                if (result.Success)
                {
                    PeopleInfo people = result.Result as PeopleInfo;
                    Console.WriteLine(String.Format("{0}({1}):{2}", people.Name, people.IdentityNumber, people.OrganizationName));
                }

                allDone.Set();
            }));
        }
    }

相关链接
---------
智慧山师 http://i.sdnu.edu.cn 

智慧山师开放平台 http://i.sdnu.edu.cn/open 

人人网公共主页 http://page.renren.com/601879820 

新浪微博 http://weibo.com/smartsdnu 
