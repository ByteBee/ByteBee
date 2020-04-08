using ByteBee.Framework.Abstractions.Converting;
using ByteBee.Framework.Configuring;
using ByteBee.Framework.Converting;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Standard.ConfigManagerTests
{
    [TestFixture]
    public sealed partial class ConfigManagerTest
    {
        private StandardConfigManager _config;
        private IConverterFactory _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory();

            var configStore = new InMemoryConfigStore();
            _config = new StandardConfigManager(configStore);
            _config.SetConverterFactory(_converter);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}