using System;
using ByteBee.Framework.Messaging.Contract;

namespace ByteBee.Framework.AppConstructing.Contract
{
    public interface IMessageBusConstructor
    {
        IAppConstructor SkipMessageBus();
        IAppConstructor AggregateMessageBus();
        IAppConstructor AggregateMessageBus(Action<IMessageBus> messageBusCallback);
    }
}