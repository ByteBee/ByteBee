using System;
using ByteBee.Framework.Abstractions.Converting;
using ByteBee.Framework.Converting;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.GuidCastingTests
{
    [TestFixture]
    public sealed partial class GuidCastingTest
    {
        private ITypeConverter<Guid> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<Guid>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}