using System;
using ByteBee.Framework.Converting.Contract;
using ByteBee.Framework.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.DateTimeCastingTests
{
    [TestFixture]
    public sealed partial class DateTimeCastingTest
    {
        private ITypeConverter<DateTime> _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new StandardConverterFactory().Create<DateTime>();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}