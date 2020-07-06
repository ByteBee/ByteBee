namespace ByteBee.Framework.Messaging.Abstractions
{
    public interface IMessageSubscription
    {
        void Subscribe(IMessageBus messageBus);
    }
}