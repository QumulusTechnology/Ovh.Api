using NUnit.Framework;
using NUnit.Framework.Legacy;
using Ovh.Api;
using Ovh.Api.Exceptions;
using System;

namespace Ovh.Test
{
    [TestFixture]
    public class ClientWithtManualParams
    {
        [Test]
        public void NoParamsThrowsConfigurationKeyMissingException()
        {
            Assert.Throws<ConfigurationKeyMissingException>(() => new Client());
        }

        [Test]
        public void ValidEndpointParam()
        {
            var client = new Client("ovh-eu");
            ClassicAssert.AreEqual(client.Endpoint, "https://eu.api.ovh.com/1.0/");
        }

        [Test]
        public void ValidParams()
        {
            var client =
                new Client("ovh-eu", "applicationKey", "secretKey",
                    "consumerKey", defaultTimeout: TimeSpan.FromSeconds(120));
            ClassicAssert.AreEqual(client.Endpoint, "https://eu.api.ovh.com/1.0/");
        }

        [Test]
        public void InvalidEndpointParamThrowsInvalidRegionException()
        {
            Assert.Throws<InvalidRegionException>(() => new Client("ovh-noWhere"));
        }
    }
}

