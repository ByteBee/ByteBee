using System;
using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Default.DateTimeCastingTests
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