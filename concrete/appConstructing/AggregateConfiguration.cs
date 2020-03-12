using ByteBee.Framework.AppConstructing.Abstractions;
using ByteBee.Framework.AppConstructing.Abstractions.Exceptions;
using ByteBee.Framework.Bootstrapping.Abstractions;
using ByteBee.Framework.Configuring.Abstractions;
using System;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class StandardAppConstructor
    {
        public IAppConstructor AggregateConfiguration()
        {
            return AggregateConfiguration(null);
        }

        public IAppConstructor AggregateConfiguration(Action<IConfigManager> configCallback)
        {
            if (_kernel == null)
            {
                throw new KernelNotDefinedException();
            }


            var configManager = _kernel.Resolve<IConfigManager>();
            var bootstrapper = _kernel.Resolve<IBootstrapper>();

            bootstrapper.ConfigureAll(configManager);
            configCallback?.Invoke(configManager);

            return this;
        }
    }
}