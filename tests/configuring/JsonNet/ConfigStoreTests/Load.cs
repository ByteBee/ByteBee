using System;
using System.IO;
using ByteBee.Framework.Configuring.Abstractions.Exceptions;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.JsonNet.ConfigStoreTests
{
    public sealed partial class ConfigStoreTest
    {
        [Test]
        public void Load_NoFile_FileNotFoundException()
        {
            _fileMoq.Setup(f => f.Exists(It.IsAny<string>()))
                .Returns(false);

            Action act = () => _store.Load(_config);

            act.Should()
                .ThrowExactly<FileNotFoundException>("no config file is there")
                .WithMessage("Configuration * does not exists.");
        }

        [Test]
        public void Load_EmptyFile_ConfigException()
        {
            ReadAllTextMock("");
            
            Action act = () => _store.Load(_config);

            act.Should()
                .ThrowExactly<ConfigurationException>("empty jsons are not allowed");
        }

        [Test]
        public void Load_EmptyJsonFile_NoEntries()
        {
            ReadAllTextMock("{}");

            _store.Load(_config);

            _config.GetSections().Should()
                .BeEmpty("the config file was empty");
        }


        [Test]
        public void Load_OneSectionOneKeyStringValue_ValidObject()
        {
            ReadAllTextMock("{\"foobar\":{\"foo\":\"bar\"}}");

            _store.Load(_config);

            using (new AssertionScope())
            {
                _config.GetSections().Should()
                    .HaveCount(1, "there is only one element");

                _config.Get<string>("foobar", "foo").Should()
                    .Be("bar", "the value of foobar.foo is bar");
            }
        }

        [Test]
        public void Load_OneSectionOneKeyIntValue_ValidObject()
        {
            ReadAllTextMock("{\"foobar\":{\"foo\":42}}");

            _store.Load(_config);

            using (new AssertionScope())
            {
                _config.GetSections().Should()
                    .HaveCount(1, "there is only one element");

                _config.Get<int>("foobar", "foo").Should()
                    .Be(42, "the value of foobar.foo is 42");
            }
        }
    }
}