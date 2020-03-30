using ByteBee.Framework.Abstractions.Converting;
using ByteBee.Framework.Converting;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.BooleanCastingTests
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