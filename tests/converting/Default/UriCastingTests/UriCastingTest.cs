using System;
using ByteBee.Framework.Abstractions.Converting;
using ByteBee.Framework.Converting;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.UriCastingTests
{
    [TestFixture]
    public sealed partial class UriCastingTest
    {
        private ITypeConverter<Uri> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<Uri>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}