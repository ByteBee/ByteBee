using ByteBee.Framework.Configuring;
using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Injecting.Abstractions;

namespace ByteBee.Framework.Tests.Stubbing.CrossCuttingLayer.MadLib
{
    public class InfrastructureModule : IKernelModule
    {
        public void Load(IKernel kernel)
        {
            kernel.Register<IConfigStore, InMemoryConfigStore>();
        }
    }
}