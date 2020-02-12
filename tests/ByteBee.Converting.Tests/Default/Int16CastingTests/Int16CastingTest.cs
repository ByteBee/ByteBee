using ByteBee.Converting.Contract;
using ByteBee.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.Int16CastingTests
{
    [TestFixture]
    public sealed partial class Int16CastingTest
    {
        private ITypeConverter<short> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<short>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}