using System;
using System.Collections.Generic;
using ByteBee.Framework.Abstractions.Bootstrapping;
using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;
using ByteBee.Framework.Abstractions.Messaging;

namespace ByteBee.Framework.Bootstrapping
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class StandardBootstrapper : IBootstrapper
    {
        private readonly List<IComponentActivator> _lifecycles;

        public StandardBootstrapper(List<IComponentActivator> lifecycles)
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

        public void ConfigureAll(IConfigManager config)
        {
            Each(b => b.Configure(config));
        }

        public void SubscribeAll(IMessageBus messageBus)
        {
            Each(b => b.Subscribe(messageBus));
        }

        public void Each(Action<IComponentActivator> callback)
        {
            _lifecycles.ForEach(callback);
        }

        public void Dispose()
        {
            _lifecycles.Clear();
        }
    }
}