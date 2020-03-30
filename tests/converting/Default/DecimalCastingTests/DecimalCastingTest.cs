using ByteBee.Framework.Abstractions.Converting;
using ByteBee.Framework.Converting;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.DecimalCastingTests
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