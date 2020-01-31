﻿using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Configurating.Tests.Default.ConfigurationSourceTests
{
    public sealed partial class ConfigurationSourceTest
    {
        [Test]
        public void GetSections_NoElements_EmptyResultReturned()
        {
            IEnumerable<string> sections = _source.GetSections();

            sections.Should().BeEmpty("there are no items before");
        }

        [Test]
        public void GetSections_ThreeSectionsDefined_AllSectionsReturned()
        {
            _source.Set("foo", "test", 1);
            _source.Set("bar", "test", 2);
            _source.Set("baz", "test", 3);

            IEnumerable<string> sections = _source.GetSections();

            sections.Should().NotBeEmpty("there are no items before")
                .And.Contain("foo", "foo was defined")
                .And.Contain("bar", "bar was defined")
                .And.Contain("baz", "baz was defined");
        }
    }
}