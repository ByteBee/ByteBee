using ByteBee.Framework.Messaging.Impl;
using NUnit.Framework;

namespace ByteBee.Messaging.Tests.Default.MessageBusTests
{
    [TestFixture]
    public sealed partial class MessageBusTest
    {
        private StandardMessageBus _bus;

        [SetUp]
        public void Setup()
        {
            _bus = new StandardMessageBus();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}