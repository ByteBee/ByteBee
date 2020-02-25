using System;

namespace ByteBee.Framework.Messaging.Contract.DataClasses
{
    public sealed class MessageBusErrorEventArgs : EventArgs
    {
        public IMessage Message { get; }
        public Exception Exception { get; }

        public MessageBusErrorEventArgs(IMessage message, Exception exception)
        {
            Message = message;
            Exception = exception;
        }
    }
}