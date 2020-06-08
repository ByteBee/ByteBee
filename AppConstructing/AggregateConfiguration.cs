using System;
using ByteBee.Framework.Abstractions.AppConstructing;
using ByteBee.Framework.Abstractions.AppConstructing.Exceptions;
using ByteBee.Framework.Abstractions.Bootstrapping;
using ByteBee.Framework.Abstractions.Configuring;

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
            
            configCallback?.Invoke(configManager);
            bootstrapper.ConfigureAll(configManager);

            return this;
        }

        private void DisposeConfiguration()
        {
            var config = _kernel.Resolve<IConfigManager>();
            config.Dispose();
        }
    }
}