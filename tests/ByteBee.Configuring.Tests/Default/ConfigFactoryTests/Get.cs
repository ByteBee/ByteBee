﻿using ByteBee.Framework.Configuring.Tests.Stub;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.Default.ConfigFactoryTests
{
    public sealed partial class ConfigFactoryTest
    {
        [Test]
        public void Get_NoEntries_EmptyObject()
        {
            var cfg = _provider.Get<TestConfig>();

            using (new AssertionScope())
            {
                cfg.StringValue.Should().BeNull();
                cfg.BoolValue.Should().BeFalse();
                cfg.IntValue.Should().Be(0);
                cfg.DoubleValue.Should().Be(0);
                cfg.UriValue.Should().BeNull();
            }
        }

        [Test]
        public void Get_StringWasSet_NoErrors()
        {
            _sourceMock.Setup(s => s.Get<string>("test", "string"))
                .Returns(() => "hello world");

            var cfg = _provider.Get<TestConfig>();

            cfg.StringValue.Should().Be("hello world");
        }

        [Test]
        public void Get_IntWasSet_NoErrors()
        {
            _sourceMock.Setup(s => s.Get<int>("test", "int"))
                .Returns(() => 42);

            var cfg = _provider.Get<TestConfig>();

            cfg.IntValue.Should().Be(42);
        }

        [Test]
        public void Get_DoubleWasSet_NoErrors()
        {
            _sourceMock.Setup(s => s.Get<double>("test", "double"))
                .Returns(() => 3.1415);

            var cfg = _provider.Get<TestConfig>();

            cfg.DoubleValue.Should().Be(3.1415);
        }

        [Test]
        public void Get_BoolWasSet_NoErrors()
        {
            _sourceMock.Setup(s => s.Get<bool>("test", "bool"))
                .Returns(() => true);

            var cfg = _provider.Get<TestConfig>();

            cfg.BoolValue.Should().BeTrue();
        }
    }
}