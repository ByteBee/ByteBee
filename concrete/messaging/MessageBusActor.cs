using System;

namespace ByteBee.Framework.Messaging
{
    internal sealed class MessageBusActor
    {
        public Delegate Handler { get; set; }
        public Delegate Filter { get; set; }
        public Type ResolverType { get; set; }
    }
}