using System;
using ByteBee.Framework.Abstractions.Configuring.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Default.ConfigManagerTests
{
    public sealed partial class ConfigManagerTest
    {
        [Test]
        public void Get_UnknownSection_Exception()
        {
            _config.Set("test", "foo", 42);

            Action act = () => _config.Get<int>("foobar", "foo");

            act.Should()
                .ThrowExactly<SectionOrKeyNotFoundException>("there is no such item");
        }
        
        [Test]
        public void Get_UnknownKey_Exception()
        {
            _config.Set("test", "foo", 42);
            
            Action act = () => _config.Get<int>("test", "bar");

            act.Should()
                .ThrowExactly<SectionOrKeyNotFoundException>("there is no such item");
        }

        [Test]
        public void Get_ItemDefined_ValueReturned()
        {
            _config.Set("test", "key", 42);

            int sinOfLife = _config.Get<int>("test", "key");

            sinOfLife.Should().Be(42, "this has been put into the config");
        }
    }
}