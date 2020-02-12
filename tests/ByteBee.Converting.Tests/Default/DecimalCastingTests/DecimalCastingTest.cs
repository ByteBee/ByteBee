using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.DecimalCastingTests
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