using System;
using ByteBee.Framework.Configuring.Abstractions;

namespace ByteBee.Framework.AppConstructing.Abstractions
{
    public interface IConfigConstructor
    {
        IMessageBusConstructor SkipConfiguration();
        IMessageBusConstructor AggregateConfiguration();
        IMessageBusConstructor AggregateConfiguration(Action<IConfigManager> configCallback);
    }
}