using System;
using ByteBee.Framework.Adapting.Contract;
using ByteBee.Framework.Configuring.Impl.JsonNet;
using Moq;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.JsonNet.ConfigurationStoreTests
{
    [TestFixture]
    public sealed partial class ConfigurationStoreTest
    {
        private JsonNetConfigurationStore _store;
        private Mock<ISystemFile> _fileMoq;

        [SetUp]
        public void Setup()
        {
            _fileMoq = new Mock<ISystemFile>();
            
            _store = new JsonNetConfigurationStore("test.cfg");
            _store.SetFileAdapter(_fileMoq.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }

        private void WriteAllTextMock(Action<string> doWithContent)
        {
            _fileMoq.Setup(f => f.WriteAllText(It.IsAny<string>(), It.IsAny<string>()))
                .Callback<string, string>((p, content) =>
                {
                    content = content.Replace(" ", "");
                    content = content.Replace(Environment.NewLine, "");
                    doWithContent(content);
                });
        }

        private void ReadAllTextMock(string fileContent)
        {
            _fileMoq.Setup(f => f.Exists(It.IsAny<string>()))
                .Returns(true);

            _fileMoq.Setup(f => f.ReadAllText(It.IsAny<string>()))
                .Returns(() => fileContent);
        }
    }
}