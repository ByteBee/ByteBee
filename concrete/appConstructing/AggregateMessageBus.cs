using System;
using ByteBee.Framework.AppConstructing.Abstractions;
using ByteBee.Framework.Messaging;
using ByteBee.Framework.Messaging.Abstractions;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class ConstructApp : IMessageBusConstructor
    {
        private IMessageBus _messageBus;

        public IAppConstructor SkipMessageBus()
        {
            return this;
        }

        public IAppConstructor AggregateMessageBus()
        {
            return AggregateMessageBus(null);
        }

        public IAppConstructor AggregateMessageBus(Action<IMessageBus> messageBusCallback)
        {
            _messageBus = _kernel.Resolve<IMessageBus>();

            _bootstrapper.SubscribeAll(_messageBus);

            messageBusCallback?.Invoke(_messageBus);

            return this;
        }
    }
}