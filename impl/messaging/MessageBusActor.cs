using System;

namespace ByteBee.Framework.Messaging.Impl
{
    internal sealed class MessageBusActor
    {
        public Delegate Handler { get; set; }
        public Delegate Filter { get; set; }
    }
}