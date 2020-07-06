using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Standard.Int64CastingTests
{
    [TestFixture]
    public sealed partial class Int64CastingTests
    {
        private ITypeConverter<long> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<long>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}