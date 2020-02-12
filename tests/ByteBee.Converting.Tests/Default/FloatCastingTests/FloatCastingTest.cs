using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.FloatCastingTests
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