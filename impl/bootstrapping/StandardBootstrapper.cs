using System;
using System.Collections.Generic;
using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Injecting.Contract;
using ByteBee.Framework.Messaging.Contract;

namespace ByteBee.Framework.Bootstrapping.Impl
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class StandardBootstrapper : IBootstrapper
    {
        private readonly List<ILifecycle> _lifecycles;

        public StandardBootstrapper(List<ILifecycle> lifecycles)
        {
            _lifecycles = lifecycles;
        }

        public void ActivateAll()
        {
            Each(b => b.Activate());
        }

        public void DeactivateAll()
        {
            Each(b => b.Deactivate());
        }

        public void RegisterAll(IBeeKernel kernel)
        {
            Each(b => b.Register(kernel));
        }

        public void ConfigureAll(IConfigFactory config)
        {
            Each(b => b.Configure(config));
        }

        public void SubscribeAll(IMessageBus messageBus)
        {
            Each(b => b.Subscribe(messageBus));
        }

        public void Each(Action<ILifecycle> callback)
        {
            _lifecycles.ForEach(callback);
        }
    }
}