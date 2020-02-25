using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.StringCastingTests
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