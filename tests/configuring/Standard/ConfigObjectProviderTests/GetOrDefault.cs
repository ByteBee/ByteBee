﻿using ByteBee.Framework.Tests.Configuring.Stub;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Standard.ConfigObjectProviderTests
{
    public sealed partial class ConfigObjectProviderTest
    {
        [Test]
        public void GetOrDefault_NoEntries_EmptyObject()
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
        public void GetOrDefault_StringWasSet_NoErrors()
        {
            _configMock.Setup(s => s.GetOrDefault<string>("test", "string"))
                .Returns(() => "hello world");

            var cfg = _provider.Get<TestConfig>();

            cfg.StringValue.Should().Be("hello world");
        }

        [Test]
        public void GetOrDefault_IntWasSet_NoErrors()
        {
            _configMock.Setup(s => s.GetOrDefault<int>("test", "int"))
                .Returns(() => 42);

            var cfg = _provider.Get<TestConfig>();

            cfg.IntValue.Should().Be(42);
        }

        [Test]
        public void GetOrDefault_DoubleWasSet_NoErrors()
        {
            _configMock.Setup(s => s.GetOrDefault<double>("test", "double"))
                .Returns(() => 3.1415);

            var cfg = _provider.Get<TestConfig>();

            cfg.DoubleValue.Should().Be(3.1415);
        }

        [Test]
        public void GetOrDefault_BoolWasSet_NoErrors()
        {
            _configMock.Setup(s => s.GetOrDefault<bool>("test", "bool"))
                .Returns(() => true);

            var cfg = _provider.Get<TestConfig>();

            cfg.BoolValue.Should().BeTrue();
        }
    }
}