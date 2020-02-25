using ByteBee.Framework.Configuring;
using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Default.ConfigurationTests
{
    [TestFixture]
    public sealed partial class ConfigurationTest
    {
        private StandardConfigManager _source;
        private IConverterFactory _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory();

            var configStore = new InMemoryConfigStore();
            _source = new StandardConfigManager(configStore);
            _source.SetConverterFactory(_converter);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}