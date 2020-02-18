using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Configuring.Impl;
using Moq;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.Default.ConfigObjectProviderTests
{
    [TestFixture]
    public sealed partial class ConfigObjectProviderTest
    {
        private Mock<IConfiguration> _sourceMock;
        private StandardConfigObjectProvider _provider;

        [SetUp]
        public void Setup()
        {
            _sourceMock = new Mock<IConfiguration>();

            _provider = new StandardConfigObjectProvider(_sourceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}