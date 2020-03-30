using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using NUnit.Framework;
using System;
using System.IO;
using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Configuring.Exceptions;

namespace ByteBee.Framework.Tests.Configuring.JsonNet.ConfigStoreTests
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
            var source = new Mock<IConfigManager>();
            IConfigManager config = source.Object;
            _store.Initialize(config);

            _store.Load();

            config.GetSections().Should()
                .BeEmpty("the config file was empty");
        }

        [Test]
        public void Load_OneSectionOneKeyStringValue_ValidObject()
        {
            ReadAllTextMock("{\"foobar\":{\"foo\":\"bar\"}}");
            var source = new Mock<IConfigManager>();
            source.Setup(cfg => cfg.GetSections()).Returns(new[] { "foobar" });
            source.Setup(cfg => cfg.Get<string>("foobar", "foo")).Returns("bar");
            IConfigManager config = source.Object;
            _store.Initialize(config);

            _store.Load();

            using (new AssertionScope())
            {
                config.GetSections().Should()
                    .HaveCount(1, "there is only one element");

                config.Get<string>("foobar", "foo").Should()
                    .Be("bar", "the value of foobar.foo is bar");
            }
        }

        [Test]
        public void Load_OneSectionOneKeyIntValue_ValidObject()
        {
            ReadAllTextMock("{\"foobar\":{\"foo\":42}}");
            var source = new Mock<IConfigManager>();
            source.Setup(cfg => cfg.GetSections()).Returns(new[] { "foobar" });
            source.Setup(cfg => cfg.Get<int>("foobar", "foo")).Returns(42);
            IConfigManager config = source.Object;
            _store.Initialize(config);

            _store.Load();

            using (new AssertionScope())
            {
                config.GetSections().Should()
                    .HaveCount(1, "there is only one element");

                config.Get<int>("foobar", "foo").Should()
                    .Be(42, "the value of foobar.foo is 42");
            }
        }
    }
}