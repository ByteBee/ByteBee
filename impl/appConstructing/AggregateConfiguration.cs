using System;
using ByteBee.Framework.AppConstructing.Contract;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Configuring.Impl;

namespace ByteBee.Framework.AppConstructing.Impl
{
    public sealed partial class ConstructApp : IConfigConstructor
    {
        private IConfiguration _source;
        public IMessageBusConstructor SkipConfiguration()
        {
            return this;
        }

        public IMessageBusConstructor AggregateConfiguration()
        {
            return AggregateConfiguration(null);
        }

        public IMessageBusConstructor AggregateConfiguration(Action<IConfiguration> configCallback)
        {
            _kernel.Register<IConfiguration, StandardConfiguration>();
            _kernel.Register<IConfigObjectProvider, StandardConfigObjectProvider>();

            _source = _kernel.Resolve<IConfiguration>();

            _bootstrapper.ConfigureAll(_source);

            configCallback?.Invoke(_source);

            return this;
        }
    }
}