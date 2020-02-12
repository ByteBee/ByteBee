using System.Collections.Generic;
using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Injecting.Contract;
using ByteBee.Framework.Messaging.Contract;

namespace ByteBee.Framework.Bootstrapping.Impl
{
    public class StandardBootstrapper : IBootstrapper
    {
        private readonly List<ILifecycle> _lifecycles;
        private readonly IBeeKernel _kernel;
        private readonly IConfigFactory _config;
        private readonly IMessageBus _messageBus;

        public StandardBootstrapper(List<ILifecycle> lifecycles, IBeeKernel kernel, IConfigFactory config, IMessageBus messageBus)
        {
            _lifecycles = lifecycles;
            _kernel = kernel;
            _config = config;
            _messageBus = messageBus;
        }

        public void Construct()
        {
            _lifecycles.ForEach(b => b.Constructor());
        }

        public void Destruct()
        {
            _lifecycles.ForEach(b => b.Destructor());
        }

        public void RegisterBindings()
        {
            _lifecycles.ForEach(b => b.RegisterBindings(_kernel));
        }

        public void Configure()
        {
            _lifecycles.ForEach(b => b.Configure(_config));
        }

        public void AddSubscriptions()
        {
            _lifecycles.ForEach(b => b.AddSubscriptions(_messageBus));
        }

        public void Activate()
        {
            RegisterBindings();
            Configure();
            AddSubscriptions();
            Construct();
        }

        public void Deactivate()
        {
            Destruct();
        }
    }
}