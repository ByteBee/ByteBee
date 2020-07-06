using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Standard.DecimalCastingTests
{
    [TestFixture]
    public sealed partial class DecimalCastingTest
    {
        private ITypeConverter<decimal> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<decimal>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}