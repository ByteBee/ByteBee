using System;
using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;
using ByteBee.Framework.Abstractions.Messaging;

namespace ByteBee.Framework.Abstractions.Bootstrapping
{
    public interface IBootstrapper
    {
        void ActivateAll();
        void DeactivateAll();
        void RegisterAll(IBeeKernel kernel);
        void ConfigureAll(IConfigManager config);
        void SubscribeAll(IMessageBus messageBus);
        void Each(Action<IComponentActivator> callback);
    }
}