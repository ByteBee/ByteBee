using System;
using ByteBee.Framework.Configuring.Abstractions.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Default.ConfigurationTests
{
    public sealed partial class ConfigurationTest
    {
        [Test]
        public void Get_UnknownSection_Exception()
        {
            _source.Set("test", "foo", 42);

            Action act = () => _source.Get<int>("foobar", "foo");

            act.Should()
                .ThrowExactly<SectionOrKeyNotFoundException>("there is no such item");
        }
        
        [Test]
        public void Get_UnknownKey_Exception()
        {
            _source.Set("test", "foo", 42);
            
            Action act = () => _source.Get<int>("test", "bar");

            act.Should()
                .ThrowExactly<SectionOrKeyNotFoundException>("there is no such item");
        }

        [Test]
        public void Get_ItemDefined_ValueReturned()
        {
            _source.Set("test", "key", 42);

            int sinOfLife = _source.Get<int>("test", "key");

            sinOfLife.Should().Be(42, "this has been put into the config");
        }
    }
}