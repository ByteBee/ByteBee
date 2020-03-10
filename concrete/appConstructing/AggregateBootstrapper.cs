using System;
using ByteBee.Framework.AppConstructing.Abstractions;
using ByteBee.Framework.Bootstrapping;
using ByteBee.Framework.Bootstrapping.Abstractions;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class ConstructApp : IBootstrapperConstructor
    {
        private IBootstrapper _bootstrapper;

        //public IConfigConstructor SkipBootstrapper()
        //{
        //    return this;
        //}

        public IConfigConstructor AggregateBootstrapper()
        {
            return AggregateBootstrapper(null);
        }

        public IConfigConstructor AggregateBootstrapper(Action<IComponentActivator> lifecycleCallback)
        {
            _bootstrapper = _kernel.Resolve<IBootstrapper>();
            _bootstrapper.RegisterAll(_kernel);
            _bootstrapper.ActivateAll();

            if (lifecycleCallback != null)
            {
                _bootstrapper.Each(lifecycleCallback);
            }

            return this;
        }
    }
}