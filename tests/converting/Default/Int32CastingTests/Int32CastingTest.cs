using ByteBee.Framework.Abstractions.Converting;
using ByteBee.Framework.Converting;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.Int32CastingTests
{
    [TestFixture]
    public sealed partial class Int32CastingTest
    {
        private ITypeConverter<int> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<int>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}