using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.BooleanCastingTests
{
    [TestFixture]
    public sealed partial class BoolConverterTest
    {
        private ITypeConverter<bool> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<bool>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}