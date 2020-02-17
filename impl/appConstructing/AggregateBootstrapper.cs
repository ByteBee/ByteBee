using System;
using ByteBee.Framework.AppConstructing.Contract;
using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Bootstrapping.Impl;

namespace ByteBee.Framework.AppConstructing.Impl
{
    public sealed partial class ConstructApp : IBootstrapperConstructor
    {
        private IBootstrapper _bootstrapper;

        public IConfigConstructor SkipBootstrapper()
        {
            return this;
        }

        public IConfigConstructor AggregateBootstrapper()
        {
            return AggregateBootstrapper(null);
        }

        public IConfigConstructor AggregateBootstrapper(Action<ILifecycle> lifecycleCallback)
        {
            _kernel.Register<IBootstrapper, StandardBootstrapper>();

            _bootstrapper = _kernel.Resolve<IBootstrapper>();
            _bootstrapper.ActivateAll();
            _bootstrapper.RegisterAll(_kernel);

            if (lifecycleCallback != null)
            {
                _bootstrapper.Each(lifecycleCallback);
            }

            return this;
        }
    }
}