using ByteBee.Framework.Configuring.Impl;
using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.Default.ConfigurationTests
{
    [TestFixture]
    public sealed partial class ConfigurationTest
    {
        private StandardConfiguration _source;
        private IConverterFactory _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory();

            _source = new StandardConfiguration();
            _source.SetConverterFactory(_converter);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}