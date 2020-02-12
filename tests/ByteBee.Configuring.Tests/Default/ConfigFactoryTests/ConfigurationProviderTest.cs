using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Configuring.Impl;
using Moq;
using NUnit.Framework;

namespace ByteBee.Framework.Configuring.Tests.Default.ConfigFactoryTests
{
    [TestFixture]
    public sealed partial class ConfigFactoryTest
    {
        private Mock<IConfigSource> _sourceMock;
        private StandardConfigFactory _provider;

        [SetUp]
        public void Setup()
        {
            _sourceMock = new Mock<IConfigSource>();

            _provider = new StandardConfigFactory(_sourceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}