using System.Net.Http;
using NUnit.Framework;
using Ovh.Api.Testing;
using System;
using FakeItEasy;
using System.Linq;
using Ovh.Test.Models;
using Ovh.Api;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace Ovh.Test;

[TestFixture]
public class PutRequests
{
    static long _currentClientTimestamp = 1566485765;
    static long _currentServerTimestamp = 1566485767;
    static DateTimeOffset _currentDateTime = DateTimeOffset.FromUnixTimeSeconds(_currentClientTimestamp);
    static ITimeProvider _timeProvider = A.Fake<ITimeProvider>();

    public PutRequests()
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
    public async Task PUT_with_raw_string_data_and_string_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Put.me_contact_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PutStringAsync("/me/contact", "Fake content");
        ClassicAssert.AreEqual(Responses.Put.me_contact_content, result);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        Assert.Multiple(() => {
            ClassicAssert.AreEqual(HttpMethod.Put, requestMessage.Method);
            ClassicAssert.AreEqual(Constants.ApplicationKey, headers.GetValues(Client.OvhAppHeader).First());
            ClassicAssert.AreEqual(Constants.ConsumerKey, headers.GetValues(Client.OvhConsumerHeader).First());
            ClassicAssert.AreEqual(_currentServerTimestamp.ToString(), headers.GetValues(Client.OvhTimeHeader).First());
            ClassicAssert.AreEqual("$1$5e81842c0f0c806fd703de084d80192a59bc0f8a", headers.GetValues(Client.OvhSignatureHeader).First());
        });
    }


    [Test]
    public async Task PUT_with_string_to_be_serialized_data_and_string_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Put.me_contact_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PutAsync("/me/contact", "Fake content");
        ClassicAssert.AreEqual(Responses.Put.me_contact_content, result);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        Assert.Multiple(() => {
            ClassicAssert.AreEqual(HttpMethod.Put, requestMessage.Method);
            ClassicAssert.AreEqual(Constants.ApplicationKey, headers.GetValues(Client.OvhAppHeader).First());
            ClassicAssert.AreEqual(Constants.ConsumerKey, headers.GetValues(Client.OvhConsumerHeader).First());
            ClassicAssert.AreEqual(_currentServerTimestamp.ToString(), headers.GetValues(Client.OvhTimeHeader).First());
            ClassicAssert.AreEqual("$1$ec5195342ad1c81073c2eb3f3d83dd20942c4408", headers.GetValues(Client.OvhSignatureHeader).First());
        });
    }

    [Test]
    public async Task PUT_with_raw_string_data_and_T_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Put.me_contact_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PutAsync<Contact>("/me/contact", "Fake content");
        ClassicAssert.AreEqual("00000", result.Address.Zip);
    }

    [Test]
    public async Task PUT_with_no_data_and_string_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Put.me_contact_message);

        var patch = new {address = new {line1 = "Hey there"} };

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PutAsync("/me/contact");
        ClassicAssert.AreEqual(Responses.Put.me_contact_content, result);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        ClassicAssert.AreEqual("$1$5595b180f954de130f8da7a5a4b55adc3d27556f", headers.GetValues(Client.OvhSignatureHeader).First());
    }


    [Test]
    public async Task PUT_with_no_data_and_T_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Put.me_contact_message);

        var patch = new {address = new {line1 = "Hey there"} };

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PutAsync<Contact>("/me/contact");
        ClassicAssert.AreEqual("00000", result.Address.Zip);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        ClassicAssert.AreEqual("$1$5595b180f954de130f8da7a5a4b55adc3d27556f", headers.GetValues(Client.OvhSignatureHeader).First());
    }

    [Test]
    public async Task PUT_with_T_data_and_T_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Put.me_contact_message);

        var patch = new {address = new {line1 = "Hey there"} };

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PutAsync<Contact>("/me/contact", patch);
        ClassicAssert.AreEqual("00000", result.Address.Zip);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        ClassicAssert.AreEqual("$1$747cdaf92e412ea434a387e6ff7b20150ee1172f", headers.GetValues(Client.OvhSignatureHeader).First());
    }
}