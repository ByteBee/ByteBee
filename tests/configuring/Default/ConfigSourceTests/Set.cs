using System;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.Default.ConfigSourceTests
{
    public sealed partial class ConfigSourceTest
    {
        [Test]
        public void Set_SectionIsNull_ArgumentNullException()
        {
            Action act = () => _source.Set(null, "foo", 1);

            act.Should()
                .ThrowExactly<ArgumentNullException>("null is not allows as section name");
        }

        [Test]
        public void Set_SectionIsEmpty_ArgumentException()
        {
            Action act = () => _source.Set("", "foo", 1);

            act.Should()
                .ThrowExactly<ArgumentException>("empty is not allows as section name");
        }

        [Test]
        public void Set_SectionIsWhitespace_ArgumentException()
        {
            Action act = () => _source.Set(" ", "foo", 1);

            act.Should()
                .ThrowExactly<ArgumentException>("whitespace is not allows as section name");
        }

        [Test]
        public void Set_KeyIsNull_ArgumentNullException()
        {
            Action act = () => _source.Set("foo", null, 1);

            act.Should()
                .ThrowExactly<ArgumentNullException>("null is not allows as key name");
        }

        [Test]
        public void Set_KeyIsEmpty_ArgumentException()
        {
            Action act = () => _source.Set("foo", "", 1);

            act.Should()
                .ThrowExactly<ArgumentException>("empty is not allows as key name");
        }

        [Test]
        public void Set_KeyIsWhitespace_ArgumentException()
        {
            Action act = () => _source.Set("foo", " ", 1);

            act.Should()
                .ThrowExactly<ArgumentException>("whitespace is not allows as key name");
        }

        [Test]
        public void Set_NoElements_OneValue()
        {
            _source.Set("foobar", "foo", "test");

            _source.NumberOfEntries
                .Should().Be(1, "we have add one element");
        }

        [Test]
        public void Set_OneElement_TwoElements()
        {
            _source.Set("foobar", "foo", "test");
            
            _source.Set("foobar", "bar", "test");

            _source.NumberOfEntries
                .Should().Be(2, "we have add another one");
        }

        [Test]
        public void Set_SameElement_OneElements()
        {
            _source.Set("foobar", "foo", "test");
            
            _source.Set("foobar", "foo", "test");

            _source.NumberOfEntries
                .Should().Be(1, "we don't need the same element twice");
        }
    }
}