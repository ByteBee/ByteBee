using System;
using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Messaging.Abstractions;

namespace ByteBee.Framework.Bootstrapping.Abstractions
{
    public interface IBootstrapper
    {
        void ActivateAll();
        void DeactivateAll();
        void RegisterAll(IBeeKernel kernel);
        void ConfigureAll(IConfigManager config);
        void SubscribeAll(IMessageBus messageBus);
        void Each(Action<ILifecycle> callback);
    }
}