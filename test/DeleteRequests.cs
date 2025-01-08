using System.Net.Http;
using NUnit.Framework;
using Ovh.Api;
using Ovh.Api.Testing;
using System;
using FakeItEasy;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace Ovh.Test;

[TestFixture]
public class DeleteRequests
{
    private const long CurrentClientTimestamp = 1566485765;
    private const long CurrentServerTimestamp = 1566485767;
    private static readonly DateTimeOffset CurrentDateTime = DateTimeOffset.FromUnixTimeSeconds(CurrentClientTimestamp);
    private static readonly ITimeProvider TimeProvider = A.Fake<ITimeProvider>();

    public DeleteRequests()
    {
        A.CallTo(() => TimeProvider.UtcNow).Returns(CurrentDateTime);
    }

    public static void MockAuthTimeCallWithFakeItEasy(FakeHttpMessageHandler fake) =>
        A.CallTo(() =>
                fake.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/auth/time"))))
            .Returns(Responses.Get.time_message);

    [Test]
    public async Task DELETE_as_string()
    {
        var fake = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(fake);

        A.CallTo(() =>
                fake.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/ip/127.0.0.1"))))
            .Returns(Responses.Delete.nullAsHttpResponseMessage);

        var c = ClientFactory.GetClient(fake);
        var result = await c.DeleteAsync("/ip/127.0.0.1");
        ClassicAssert.AreEqual(Responses.Delete.nullAsJsonString, result);

        var meCall = Fake.GetCalls(fake).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/ip/127.0.0.1")).First();

        var requestMessage = meCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        Assert.Multiple(() => {
            ClassicAssert.AreEqual(Constants.ApplicationKey, headers.GetValues(Client.OvhAppHeader).First());
            ClassicAssert.AreEqual(Constants.ConsumerKey, headers.GetValues(Client.OvhConsumerHeader).First());
            ClassicAssert.AreEqual(CurrentServerTimestamp.ToString(), headers.GetValues(Client.OvhTimeHeader).First());
            ClassicAssert.AreEqual("$1$610ebc657a19d6b444264f998291a4f24bc3227d", headers.GetValues(Client.OvhSignatureHeader).First());
        });
    }

    [Test]
    public async Task DELETE_as_T()
    {
        var fake = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(fake);

        A.CallTo(() =>
                fake.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/ip/127.0.0.1"))))
            .Returns(Responses.Get.empty_message);


        var c = ClientFactory.GetClient(fake);
        var queryParams = new QueryStringParams();
        queryParams.Add("filter", "value:&é'-");
        queryParams.Add("anotherfilter", "=test");
        var result = await c.DeleteAsync<object>("/ip/127.0.0.1");
        ClassicAssert.IsNull(result);
    }
}