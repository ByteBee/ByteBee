using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.Int64CastingTests
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