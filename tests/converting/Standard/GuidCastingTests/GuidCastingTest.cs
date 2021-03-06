﻿using System;
using ByteBee.Framework.Converting;
using ByteBee.Framework.Converting.Abstractions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Converting.Standard.GuidCastingTests
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