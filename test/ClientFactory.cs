using System;
using System.Net.Http;
using Ovh.Api;

namespace Ovh.Test;

public static class ClientFactory
{
    public static Client GetClient(FakeHttpMessageHandler handler, bool withConsumerKey = true, TimeSpan? timeout = null) 
        => 
            withConsumerKey 
                ? new Client(Constants.Endpoint, Constants.ApplicationKey, Constants.ApplicationSecret, Constants.ConsumerKey, httpClient: new HttpClient(handler), defaultTimeout: timeout) 
                : new Client(Constants.Endpoint, Constants.ApplicationKey, Constants.ApplicationSecret, httpClient: new HttpClient(handler), defaultTimeout: timeout);
}