using System;
using System.IO;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Configuring.Contract.Exceptions;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.JsonNet.ConfigStoreTests
{
    public sealed partial class ConfigStoreTest
    {
        [Test]
        public void Load_NoFile_FileNotFoundException()
        {
            _fileMoq.Setup(f => f.Exists(It.IsAny<string>()))
                .Returns(false);

            Action act = () => _store.Load();

            act.Should()
                .ThrowExactly<FileNotFoundException>("no config file is there")
                .WithMessage("Configuration * does not exists.");
        }

        [Test]
        public void Load_EmptyFile_ConfigException()
        {
            ReadAllTextMock("");
            
            Action act = () => _store.Load();

            act.Should()
                .ThrowExactly<ConfigurationException>("empty jsons are not allowed");
        }

        [Test]
        public void Load_EmptyJsonFile_NoEntries()
        {
            ReadAllTextMock("{}");

            IConfiguration source = _store.Load();

            source.GetSections().Should()
                .BeEmpty("the config was empty");
        }


        [Test]
        public void Load_OneSectionOneKeyStringValue_ValidObject()
        {
            ReadAllTextMock("{\"foobar\":{\"foo\":\"bar\"}}");

            IConfiguration source = _store.Load();

            using (new AssertionScope())
            {
                source.GetSections().Should()
                    .HaveCount(1, "there is only one element");

                source.Get<string>("foobar", "foo").Should()
                    .Be("bar", "the value of foobar.foo is bar");
            }
        }

        [Test]
        public void Load_OneSectionOneKeyIntValue_ValidObject()
        {
            ReadAllTextMock("{\"foobar\":{\"foo\":42}}");

            IConfiguration source = _store.Load();

            using (new AssertionScope())
            {
                source.GetSections().Should()
                    .HaveCount(1, "there is only one element");

                source.Get<int>("foobar", "foo").Should()
                    .Be(42, "the value of foobar.foo is 42");
            }
        }
    }
}