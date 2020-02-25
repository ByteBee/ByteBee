using ByteBee.Framework.Messaging;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Messaging.Default.MessageBusTests
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