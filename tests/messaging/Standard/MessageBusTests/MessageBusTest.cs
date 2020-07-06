using System.Collections.Generic;
using ByteBee.Framework.Messaging;
using ByteBee.Framework.Messaging.Abstractions;
using Castle.Components.DictionaryAdapter;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Messaging.Standard.MessageBusTests
{
    [TestFixture]
    public sealed partial class MessageBusTest
    {
        private StandardMessageBus _bus;

        [SetUp]
        public void Setup()
        {
            _bus = new StandardMessageBus(new List<IMessageSubscription>());
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}