using ByteBee.Framework.Configuring;
using ByteBee.Framework.Configuring.Abstractions;
using Moq;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Default.ConfigObjectProviderTests
{
    [TestFixture]
    public sealed partial class ConfigObjectProviderTest
    {
        private Mock<IConfigManager> _configMock;
        private StandardConfigProvider _provider;

        [SetUp]
        public void Setup()
        {
            _configMock = new Mock<IConfigManager>();
            _provider = new StandardConfigProvider(_configMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}