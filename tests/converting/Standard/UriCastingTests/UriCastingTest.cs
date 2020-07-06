using System;
using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Standard.UriCastingTests
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