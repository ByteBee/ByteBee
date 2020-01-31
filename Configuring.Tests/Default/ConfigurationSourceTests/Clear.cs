﻿using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Configurating.Tests.Default.ConfigurationSourceTests
{
    public sealed partial class ConfigurationSourceTest
    {
        [Test]
        public void Clear_NoEntries_NoEntries()
        {
            _source.Clear();

            _source.NumberOfEntries
                .Should().Be(0, "it was cleared");
        }

        [Test]
        public void Clear_ThreeEntries_NoEntries()
        {
            _source.Set("test", "foo", 1);
            _source.Set("test", "bar", 2);
            _source.Set("test", "baz", 3);

            _source.Clear();

            _source.NumberOfEntries
                .Should().Be(0, "it was cleared");
        }
    }
}