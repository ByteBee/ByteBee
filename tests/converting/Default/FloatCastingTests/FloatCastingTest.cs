using ByteBee.Framework.Abstractions.Converting;
using ByteBee.Framework.Converting;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.FloatCastingTests
{
    [TestFixture]
    public sealed partial class FloatCastingTest
    {
        private ITypeConverter<float> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<float>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}