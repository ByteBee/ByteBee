using ByteBee.Framework.AppConstructing.Abstractions;
using ByteBee.Framework.AppConstructing.Abstractions.Exceptions;
using ByteBee.Framework.Bootstrapping.Abstractions;
using ByteBee.Framework.Messaging.Abstractions;
using System;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class StandardAppConstructor
    {
        public IAppConstructor AggregateMessageBus()
        {
            return AggregateMessageBus(null);
        }

        public IAppConstructor AggregateMessageBus(Action<IMessageBus> messageBusCallback)
        {
            if (_kernel == null)
            {
                throw new KernelNotDefinedException();
            }

            var messageBus = _kernel.Resolve<IMessageBus>();
            var bootstrapper = _kernel.Resolve<IBootstrapper>();

            messageBusCallback?.Invoke(messageBus);
            bootstrapper.SubscribeAll(messageBus);

            return this;
        }
    }
}