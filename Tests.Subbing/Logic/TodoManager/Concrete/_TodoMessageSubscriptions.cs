using System;
using ByteBee.Framework.Messaging.Abstractions;
using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Abstractions.Messages;

namespace ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Concrete
{
    public class TodoMessageSubscriptions : IMessageSubscription
    {
        public void Subscribe(IMessageBus messageBus)
        {
            messageBus.Register<TodoMessageHandler,TodoMessage>((h, m)
                => h.Create(m));
        }
    }
}