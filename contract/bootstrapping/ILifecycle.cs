using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Injecting.Contract;
using ByteBee.Framework.Messaging.Contract;

namespace ByteBee.Framework.Bootstrapping.Contract
{
    public interface ILifecycle
    {
        void Activate();
        void Deactivate();
        void Register(IBeeKernel kernel);
        void Configure(IConfigFactory config);
        void Subscribe(IMessageBus messageBus);
    }
}