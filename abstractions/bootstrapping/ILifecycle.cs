using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Messaging.Abstractions;

namespace ByteBee.Framework.Bootstrapping.Abstractions
{
    public interface ILifecycle
    {
        void Activate();
        void Deactivate();
        void Register(IBeeKernel kernel);
        void Configure(IConfigManager config);
        void Subscribe(IMessageBus messageBus);
    }
}