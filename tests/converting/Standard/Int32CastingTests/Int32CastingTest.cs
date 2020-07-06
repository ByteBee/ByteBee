using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Standard.Int32CastingTests
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