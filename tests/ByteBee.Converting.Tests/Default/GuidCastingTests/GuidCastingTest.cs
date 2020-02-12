﻿using System;
using ByteBee.Converting.Contract;
using ByteBee.Converting.Impl;
using NUnit.Framework;

namespace ByteBee.Framework.Converting.Tests.Default.GuidCastingTests
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