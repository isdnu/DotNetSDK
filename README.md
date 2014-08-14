智慧山师 .NET SDK
=========

智慧山师官方 .NET SDK，基于MIT开源协议，支持.NET 2.0、4.0以及4.0、4.5可移植库四种项目类型，覆盖.NET 2.0/4.0全部的项目以及Windows Phone Silverlight 7及以上、Windows 8（应用商店应用）及以上、Windows 8.1/Windows Phone 8.1以及Silverlight 4.0及以上等不同的应用。.NET SDK支持OAuth1.0a和XAuth两种授权方式，封装了智慧山师全部的接口，可以提供获取服务器返回的原始数据以及反序列化后的实体数据。

若要获取实体数据，首先需要创建自定义反序列化器，智慧山师支持任意Json反序列化工具，例如使用Json.NET可以使用如下的代码

    using System;
    using Newtonsoft.Json;
    using SDNUMobile.SDK;
    
    class JsonDeserializer : IJsonDeserializer
    {
        public static JsonDeserializer Instance = new JsonDeserializer();

        public T DeserializeJson<T>(String json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

接下来仅需创建客户端即可使用相关功能

    String consumerKey = "test_consumer_key_00000000000001";
    String consumerSecret = "test_consumer_secrettest_consumer_secret";

    OAuthClient client = new OAuthClient(JsonDeserializer.Instance, consumerKey, consumerSecret);

对于OAuth1.0a协议，需要按以下步骤执行

1.  获取请求令牌
2.  使用请求令牌访问授权页面并引导用户登录和授权
3.  从回调地址中获取令牌验证码
4.  使用请求令牌和验证码获取访问令牌
5.  使用访问令牌请求服务方法

1.获取请求令牌

    String callbackUrl = "http://fakeurl.com/callback";
    client.RequestRequestTokenAsync(callbackUrl, result =>
    {
        RequestToken requestToken = result.Token as RequestToken;
    });

对于客户端类无服务器的应用，可以使用默认回调地址

    client.RequestRequestTokenAsync(result =>
    {
        RequestToken requestToken = result.Token as RequestToken;
    });

2.获取授权页面地址，并引导用户登录和授权

    String authorizeUrl = client.GetAuthorizeUrl(requestToken):

3.从回调地址中获取令牌验证码

    String callback = "http://fakeurl.com/callback#oauth_token=REQTOKEN&oauth_verifier=VERIFIER";
    String verifier = client.GetVerifierFromCallbackUrl(callback);

4.使用请求令牌换取访问令牌

    client.RequestAccessTokenAsync(requestToken, verifier, result =>
    {
        AccessToken accessToken = result.Token as AccessToken;
    });

5.使用访问令牌请求服务方法

    client.RequestRestMethodAsync(new RestMethod.People.Get(), result =>
    {
        if (result.Success)
        {
            PeopleInfo people = result.Result;
            Console.WriteLine(String.Format("{0}({1}):{2}", 
                people.Name, people.IdentityNumber, people.OrganizationName));
        }
    });

对于用户状态的记录，可以使用存储凭证的方式

    String voucher = client.AccessToken.ToStorageVoucher();

存储凭证是明文存储，可以根据需要进行加密存储。用户再次使用时即可使用存储凭证初始化访问令牌。

    client.LoadAccessTokenFromVoucher(voucher);

相关链接
---------
智慧山师 http://i.sdnu.edu.cn 

智慧山师开放平台 http://i.sdnu.edu.cn/open 

人人网公共主页 http://page.renren.com/601879820 

新浪微博 http://weibo.com/smartsdnu 
