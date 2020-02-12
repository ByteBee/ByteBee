using ByteBee.Framework.Configuring.Impl;
using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;
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