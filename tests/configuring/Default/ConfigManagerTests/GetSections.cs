using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Default.ConfigManagerTests
{
    public sealed partial class ConfigManagerTest
    {
        [Test]
        public void GetSections_NoElements_EmptyResultReturned()
        {
            IEnumerable<string> sections = _config.GetSections();

            sections.Should().BeEmpty("there are no items before");
        }

        [Test]
        public void GetSections_ThreeSectionsDefined_AllSectionsReturned()
        {
            _config.Set("foo", "test", 1);
            _config.Set("bar", "test", 2);
            _config.Set("baz", "test", 3);

            IEnumerable<string> sections = _config.GetSections();

            sections.Should().NotBeEmpty("there are no items before")
                .And.Contain("foo", "foo was defined")
                .And.Contain("bar", "bar was defined")
                .And.Contain("baz", "baz was defined");
        }
    }
}