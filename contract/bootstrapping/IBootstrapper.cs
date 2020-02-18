using System;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Injecting.Contract;
using ByteBee.Framework.Messaging.Contract;

namespace ByteBee.Framework.Bootstrapping.Contract
{
    public interface IBootstrapper
    {
        void ActivateAll();
        void DeactivateAll();
        void RegisterAll(IBeeKernel kernel);
        void ConfigureAll(IConfiguration config);
        void SubscribeAll(IMessageBus messageBus);
        void Each(Action<ILifecycle> callback);
    }
}