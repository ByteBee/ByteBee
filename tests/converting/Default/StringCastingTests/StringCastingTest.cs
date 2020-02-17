using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.StringCastingTests
{
    [TestFixture]
    public sealed partial class StringCastingTest
    {
        private ITypeConverter<string> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<string>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}