using ByteBee.Framework.Adapting.Abstractions;
using ByteBee.Framework.Configuring.JsonNet;
using Moq;
using NUnit.Framework;
using System;

namespace ByteBee.Framework.Tests.Configuring.JsonNet.ConfigStoreTests
{
    [TestFixture]
    public sealed partial class ConfigStoreTest
    {
        private JsonNetConfigStore _store;
        private Mock<ISystemFile> _fileMoq;

        [SetUp]
        public void Setup()
        {
            _fileMoq = new Mock<ISystemFile>();
            
            _store = new JsonNetConfigStore("test.cfg");
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