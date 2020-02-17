using System;
using ByteBee.Framework.AppConstructing.Contract;
using ByteBee.Framework.Messaging.Contract;
using ByteBee.Framework.Messaging.Impl;

namespace ByteBee.Framework.AppConstructing.Impl
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
            _kernel.Register<IMessageBus, StandardMessageBus>();

            _messageBus = _kernel.Resolve<IMessageBus>();

            _bootstrapper.SubscribeAll(_messageBus);

            messageBusCallback?.Invoke(_messageBus);

            return this;
        }
    }
}