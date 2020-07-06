using ByteBee.Framework.Configuring;
using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Messaging;
using ByteBee.Framework.Messaging.Abstractions;

namespace ByteBee.Framework.Tests.Stubbing.Infrastructure.MadLib
{
    public sealed class InfrastructureModule : IKernelModule
    {
        public void Load(IKernel kernel)
        {
            kernel.Register<IConfigStore, InMemoryConfigStore>();
            kernel.Register<IMessageBus, StandardMessageBus>();
        }
    }
}