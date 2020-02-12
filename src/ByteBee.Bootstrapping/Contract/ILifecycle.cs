using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Injecting.Contract;
using ByteBee.Framework.Messaging.Contract;

namespace ByteBee.Framework.Bootstrapping.Contract
{
    public interface ILifecycle
    {
        void Constructor();
        void Destructor();
        void RegisterBindings(IBeeKernel kernel);
        void Configure(IConfigFactory config);
        void AddSubscriptions(IMessageBus messageBus);
    }
}