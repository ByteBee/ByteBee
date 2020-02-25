using System;
using ByteBee.Framework.AppConstructing.Abstractions;
using ByteBee.Framework.Configuring;
using ByteBee.Framework.Configuring.Abstractions;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class ConstructApp : IConfigConstructor
    {
        private IConfigManager _source;
        public IMessageBusConstructor SkipConfiguration()
        {
            return this;
        }

        public IMessageBusConstructor AggregateConfiguration()
        {
            return AggregateConfiguration(null);
        }

        public IMessageBusConstructor AggregateConfiguration(Action<IConfigManager> configCallback)
        {
            _kernel.Register<IConfigManager, StandardConfigManager>();
            _kernel.Register<IConfigObjectProvider, StandardConfigObjectProvider>();

            _source = _kernel.Resolve<IConfigManager>();

            _bootstrapper.ConfigureAll(_source);

            configCallback?.Invoke(_source);

            return this;
        }
    }
}