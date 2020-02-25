using ByteBee.Framework.Configuring;
using ByteBee.Framework.Configuring.Abstractions;
using Moq;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Configuring.Default.ConfigObjectProviderTests
{
    [TestFixture]
    public sealed partial class ConfigObjectProviderTest
    {
        private Mock<IConfigManager> _sourceMock;
        private StandardConfigObjectProvider _provider;

        [SetUp]
        public void Setup()
        {
            _sourceMock = new Mock<IConfigManager>();

            _provider = new StandardConfigObjectProvider(_sourceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}