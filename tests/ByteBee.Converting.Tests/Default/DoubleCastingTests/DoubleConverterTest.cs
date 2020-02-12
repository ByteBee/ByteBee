using ByteBee.Converting.Contract;
using ByteBee.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.DoubleCastingTests
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