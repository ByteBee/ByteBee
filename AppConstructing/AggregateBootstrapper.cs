using System;
using ByteBee.Framework.Abstractions.AppConstructing;
using ByteBee.Framework.Abstractions.AppConstructing.Exceptions;
using ByteBee.Framework.Abstractions.Bootstrapping;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class StandardAppConstructor
    {
        public IAppConstructor AggregateBootstrapper()
        {
            return AggregateBootstrapper(b => { });
        }

        public IAppConstructor AggregateBootstrapper(Action<IComponentActivator> lifecycleCallback)
        {
            if (_kernel == null)
            {
                throw new KernelNotDefinedException();
            }

            var bootstrapper = _kernel.Resolve<IBootstrapper>();

            bootstrapper.RegisterAll(_kernel);
            bootstrapper.ActivateAll();

            if (lifecycleCallback != null)
            {
                bootstrapper.Each(lifecycleCallback);
            }

            return this;
        }
    }
}