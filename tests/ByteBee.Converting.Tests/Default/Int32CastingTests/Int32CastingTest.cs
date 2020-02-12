using ByteBee.Converting.Contract;
using ByteBee.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.Int32CastingTests
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