using System;
using ByteBee.Framework.AppConstructing.Contract;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Configuring.Impl;

namespace ByteBee.Framework.AppConstructing.Impl
{
    public sealed partial class ConstructApp : IConfigConstructor
    {
        public IMessageBusConstructor SkipConfiguration()
        {
            return this;
        }

        public IMessageBusConstructor AggregateConfiguration()
        {
            return AggregateConfiguration(null);
        }

        public IMessageBusConstructor AggregateConfiguration(Action<IConfigFactory, IConfigSource> configCallback)
        {
            _kernel.Register<IConfigSource, StandardConfigSource>();
            _kernel.Register<IConfigFactory, StandardConfigFactory>();

            if (configCallback != null)
            {
                var factory = _kernel.Resolve<IConfigFactory>();
                var source = _kernel.Resolve<IConfigSource>();

                configCallback(factory, source);
            }

            return this;
        }
    }
}