using System;
using ByteBee.Framework.Messaging.Abstractions;

namespace ByteBee.Framework.AppConstructing.Abstractions
{
    public interface IMessageBusConstructor
    {
        IAppConstructor SkipMessageBus();
        IAppConstructor AggregateMessageBus();
        IAppConstructor AggregateMessageBus(Action<IMessageBus> messageBusCallback);
    }
}