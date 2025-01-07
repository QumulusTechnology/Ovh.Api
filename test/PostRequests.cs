using System.Net.Http;
using NUnit.Framework;
using Ovh.Api;
using Ovh.Api.Testing;
using System;
using FakeItEasy;
using System.Linq;
using Ovh.Test.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace Ovh.Test;

[TestFixture]
public class PostRequests
{
    static long _currentClientTimestamp = 1566485765;
    static long _currentServerTimestamp = 1566485767;
    static DateTimeOffset _currentDateTime = DateTimeOffset.FromUnixTimeSeconds(_currentClientTimestamp);
    static ITimeProvider _timeProvider = A.Fake<ITimeProvider>();

    public PostRequests()
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
    public async Task POST_with_no_data_and_result_as_string()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/geolocation"))))
            .Returns(Responses.Post.me_geolocation_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PostAsync("/me/geolocation", null);
        ClassicAssert.AreEqual(Responses.Post.me_geolocation_content, result);

        var geolocCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/geolocation")).First();

        var requestMessage = geolocCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        Assert.Multiple(() => {
            ClassicAssert.AreEqual(Constants.ApplicationKey, headers.GetValues(Client.OvhAppHeader).First());
            ClassicAssert.AreEqual(Constants.ConsumerKey, headers.GetValues(Client.OvhConsumerHeader).First());
            ClassicAssert.AreEqual(_currentServerTimestamp.ToString(), headers.GetValues(Client.OvhTimeHeader).First());
            ClassicAssert.AreEqual("$1$3473ad8790d09e6d28f8a9d6f09a05c1f5f0bbfc", headers.GetValues(Client.OvhSignatureHeader).First());
        });
    }

    [Test]
    public async Task POST_with_no_data_and_result_as_T()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/geolocation"))))
            .Returns(Responses.Post.me_geolocation_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PostAsync<Geolocation>("/me/geolocation");
        ClassicAssert.AreEqual("eo", result.CountryCode);
        ClassicAssert.AreEqual("256.0.0.1", result.Ip);
        ClassicAssert.AreEqual("Atlantis", result.Continent);
    }

    [Test]
    public async Task POST_with_raw_string_data_and_string_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Post.me_contact_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PostStringAsync("/me/contact", "Fake content");
        ClassicAssert.AreEqual(Responses.Post.me_contact_content, result);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        Assert.Multiple(() => {
            ClassicAssert.AreEqual(Constants.ApplicationKey, headers.GetValues(Client.OvhAppHeader).First());
            ClassicAssert.AreEqual(Constants.ConsumerKey, headers.GetValues(Client.OvhConsumerHeader).First());
            ClassicAssert.AreEqual(_currentServerTimestamp.ToString(), headers.GetValues(Client.OvhTimeHeader).First());
            ClassicAssert.AreEqual("$1$19a8f2db1a3b2b89b231c7872332b6ba117d8bd7", headers.GetValues(Client.OvhSignatureHeader).First());
        });
    }

    [Test]
    public async Task POST_with_string_to_be_serialized_data_and_T_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Post.me_contact_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PostAsync<Contact>("/me/contact", "Fake content");
        ClassicAssert.AreEqual("deleteme@deleteme.deleteme", result.Email);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        Assert.Multiple(() => {
            ClassicAssert.AreEqual(Constants.ApplicationKey, headers.GetValues(Client.OvhAppHeader).First());
            ClassicAssert.AreEqual(Constants.ConsumerKey, headers.GetValues(Client.OvhConsumerHeader).First());
            ClassicAssert.AreEqual(_currentServerTimestamp.ToString(), headers.GetValues(Client.OvhTimeHeader).First());
            ClassicAssert.AreEqual("$1$8a6f2668c14048c59ca957bc26b16a29180ffb03", headers.GetValues(Client.OvhSignatureHeader).First());
        });
    }

    [Test]
    public async Task POST_with_string_to_be_serialized_data_and_string_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Post.me_contact_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PostAsync("/me/contact", "Fake content");
        ClassicAssert.AreEqual(Responses.Post.me_contact_content, result);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");
        var headers = requestMessage.Headers;
        Assert.Multiple(() => {
            ClassicAssert.AreEqual(Constants.ApplicationKey, headers.GetValues(Client.OvhAppHeader).First());
            ClassicAssert.AreEqual(Constants.ConsumerKey, headers.GetValues(Client.OvhConsumerHeader).First());
            ClassicAssert.AreEqual(_currentServerTimestamp.ToString(), headers.GetValues(Client.OvhTimeHeader).First());
            ClassicAssert.AreEqual("$1$8a6f2668c14048c59ca957bc26b16a29180ffb03", headers.GetValues(Client.OvhSignatureHeader).First());
        });
    }

    [Test]
    public async Task POST_with_T_data_and_string_result()
    {
        var testHandler = A.Fake<FakeHttpMessageHandler>(a => a.CallsBaseMethods());
        MockAuthTimeCallWithFakeItEasy(testHandler);
        var dummyContact = new Contact{
            Address = new Address{
                City = "deleteme",
                Country = "FR",
                Line1 = "deleteme",
                Zip = "00000"
            },
            Email = "deleteme@deleteme.deleteme",
            FirstName = "deleteme",
            Language = "fr_FR",
            LastName = "deleteme",
            LegalForm = "individual",
            Phone = "0000000000"
        };
        A.CallTo(() =>
                testHandler.Send(A<HttpRequestMessage>.That.Matches(
                    r => r.RequestUri.ToString().Contains("/me/contact"))))
            .Returns(Responses.Post.me_contact_message);

        var c = ClientFactory.GetClient(testHandler).AsTestable(_timeProvider);
        var result = await c.PostAsync<Contact>("/me/contact", dummyContact);

        //Ensure that the call went through correctly
        ClassicAssert.AreEqual(123456, result.Id);

        var contactCall = Fake.GetCalls(testHandler).Where(call =>
            call.Method.Name == "Send" &&
            call.GetArgument<HttpRequestMessage>("request").RequestUri.ToString().Contains("/me/contact")).First();

        var requestMessage = contactCall.GetArgument<HttpRequestMessage>("request");

        // Ensure that we sent a serialized version of the dummy contact
        var sendtObject = JsonConvert.DeserializeObject<Contact>(await requestMessage.Content.ReadAsStringAsync());
        ClassicAssert.AreEqual(dummyContact.Address.Country, sendtObject.Address.Country);
        ClassicAssert.AreEqual(dummyContact.Address.Zip, sendtObject.Address.Zip);
        ClassicAssert.AreEqual(dummyContact.Email, sendtObject.Email);
    }
}