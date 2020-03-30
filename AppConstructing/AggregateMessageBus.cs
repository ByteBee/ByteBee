using System;
using ByteBee.Framework.Abstractions.AppConstructing;
using ByteBee.Framework.Abstractions.AppConstructing.Exceptions;
using ByteBee.Framework.Abstractions.Bootstrapping;
using ByteBee.Framework.Abstractions.Messaging;

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