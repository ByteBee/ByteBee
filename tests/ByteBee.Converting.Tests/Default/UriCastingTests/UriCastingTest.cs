using System;
using ByteBee.Converting.Contract;
using ByteBee.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.UriCastingTests
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