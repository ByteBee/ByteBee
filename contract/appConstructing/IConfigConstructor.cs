using System;
using ByteBee.Framework.Configuring.Contract;

namespace ByteBee.Framework.AppConstructing.Contract
{
    public interface IConfigConstructor
    {
        IMessageBusConstructor SkipConfiguration();
        IMessageBusConstructor AggregateConfiguration();
        IMessageBusConstructor AggregateConfiguration(Action<IConfiguration> configCallback);
    }
}