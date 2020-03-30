using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;
using ByteBee.Framework.Abstractions.Messaging;

namespace ByteBee.Framework.Abstractions.Bootstrapping
{
    public interface IComponentActivator
    {
        void Activate();
        void Deactivate();
        void Register(IBeeKernel kernel);
        void Configure(IConfigManager config);
        void Subscribe(IMessageBus messageBus);
    }
}