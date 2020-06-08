using System;

namespace ByteBee.Framework.Messaging
{
    internal sealed class MessageBusActor : IDisposable
    {
        public Delegate Handler { get; set; }
        public Delegate Filter { get; set; }
        public Type ResolverType { get; set; }

        public void Dispose()
        {
            Handler = null;
            Filter = null;
            ResolverType = null;
        }
    }
}