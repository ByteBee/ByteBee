using ByteBee.Framework.Abstractions.Converting;
using ByteBee.Framework.Converting;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.DoubleCastingTests
{
    [TestFixture]
    public sealed partial class DoubleConverterTest
    {
        private ITypeConverter<double> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<double>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}