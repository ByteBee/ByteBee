using System;

namespace ByteBee.Framework.Messaging.Abstractions.DataClasses
{
    public sealed class MessageBusErrorEventArgs : EventArgs
    {
        public object Message { get; }
        public Exception Exception { get; }

        public MessageBusErrorEventArgs(object message, Exception exception)
        {
            Message = message;
            Exception = exception;
        }
    }
}