using System.Net.Http;
using NUnit.Framework;
using Ovh.Api;
using Ovh.Api.Testing;
using System;
using FakeItEasy;
using System.Linq;
using Ovh.Test.Models;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework.Legacy;

namespace Ovh.Test;

[TestFixture]
public class GetRequests
{
    static long _currentClientTimestamp = 1566485765;
    static long _currentServerTimestamp = 1566485767;
    static DateTimeOffset _currentDateTime = DateTimeOffset.FromUnixTimeSeconds(_currentClientTimestamp);
    static ITimeProvider _timeProvider = A.Fake<ITimeProvider>();

    public GetRequests()
    {
        A.CallTo(() => _timeProvider.UtcNow).Returns(_currentDateTime);
    }

    public static void MockAuthTimeCallWithFakeItEasy(FakeHttpMessageHandler fake)
    {
        A.CallTo(() =>
                fake.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/auth/time"))))
            .Returns(Responses.Get.time_message);
    }

    [Test]
    public async Task GET_auth_time()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);

        var httpClient = new HttpClient(testHandler);
        var c = new Client("ovh-eu", httpClient: httpClient).AsTestable(_timeProvider);

        ClassicAssert.AreEqual(2, await c.GetTimeDelta());
    }

    [Test]
    [TestCase("/me", "https://eu.api.ovh.com/1.0/me", "$1$dfe0b86bf2ab0d9eb3f785dc1ab00de58984d80c")]
    [TestCase("/v1/me", "https://eu.api.ovh.com/v1/me", "$1$b6849b8a25d6bc46c6ad1dfb0fc67d07db9553a3")]
    [TestCase("/v2/me", "https://eu.api.ovh.com/v2/me", "$1$291bb7bdbef11b1050200a109a4fe5109ed96cdd")]
    public async Task GET_me_as_string(string call, string called, string sig)
    {
        var fake = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(fake);

        A.CallTo(() =>
                fake.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me"))))
            .Returns(Responses.Get.me_message);


        var c = ClientFactory.GetClient(fake);

        var result = await c.GetAsync(call);
        ClassicAssert.AreEqual(Responses.Get.me_content, result);

        var meCall = Fake.GetCalls(fake).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me")).First();

        var requestMessage = meCall.GetArgument<HttpRequestMessage>("request");

        var uri = requestMessage.RequestUri;
        ClassicAssert.AreEqual(called, uri.AbsoluteUri);

        var headers = requestMessage.Headers;
        Assert.Multiple(() => {
            ClassicAssert.AreEqual(Constants.ApplicationKey, headers.GetValues(Client.OvhAppHeader).First());
            ClassicAssert.AreEqual(Constants.ConsumerKey, headers.GetValues(Client.OvhConsumerHeader).First());
            ClassicAssert.AreEqual(_currentServerTimestamp.ToString(), headers.GetValues(Client.OvhTimeHeader).First());
            ClassicAssert.AreEqual(sig, headers.GetValues(Client.OvhSignatureHeader).First());
        });
    }

    [Test]
    public void GET_me_throws_when_timeout_expires()
    {
        var fake = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(fake);

        A.CallTo(() =>
                fake.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me"))))
            .Invokes(() => Thread.Sleep(1000))
            .Returns(Responses.Get.me_message);

        var c = ClientFactory.GetClient(fake, timeout: TimeSpan.Zero);
        Assert.ThrowsAsync<TaskCanceledException>(() => c.GetAsync("/me"));
    }

    [Test]
    public async Task GET_me_as_T()
    {
        var fake = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(fake);

        A.CallTo(() =>
                fake.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me"))))
            .Returns(Responses.Get.me_message);


        var c = ClientFactory.GetClient(fake);
        var result = await c.GetAsync<Me>("/me");

        ClassicAssert.AreEqual("Noname", result.Name);
        ClassicAssert.AreEqual("none-ovh", result.Nichandle);
        ClassicAssert.AreEqual("EUR", result.Currency.Code);
        ClassicAssert.AreEqual("€", result.Currency.Symbol);
    }

    [Test]
    public async Task GET_with_filter_generates_correct_signature()
    {
        var fake = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(fake);

        A.CallTo(() =>
                fake.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/route"))))
            .Returns(Responses.Get.empty_message);


        var c = ClientFactory.GetClient(fake);
        var queryParams = new QueryStringParams();
        queryParams.Add("filter", "value:&é'-");
        queryParams.Add("anotherfilter", "=test");
        _ = await c.GetAsync("/route", queryParams);


        var meCall = Fake.GetCalls(fake).First(call => call.Method.Name == "Send" &&
                                                       call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/route"));

        var requestMessage = meCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        ClassicAssert.AreEqual("$1$098b93d342b6db4848ec448063be2b6884e94723", headers.GetValues(Client.OvhSignatureHeader).First());
    }
}