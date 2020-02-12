using ByteBee.Converting.Contract;
using ByteBee.Converting.Impl;
using ByteBee.Framework.Configuring.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.Default.ConfigurationSourceTests
{
    [TestFixture]
    public sealed partial class ConfigurationSourceTest
    {
        private StandardConfigurationSource _source;
        private IConverterFactory _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory();

            _source = new StandardConfigurationSource();
            _source.SetConverterFactory(_converter);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}