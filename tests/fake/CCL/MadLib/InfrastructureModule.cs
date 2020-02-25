using ByteBee.Framework.Configuring;
using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Injecting.Abstractions;

namespace ByteBee.Framework.Tests.Fake.CCL.MadLib
{
    public class InfrastructureModule : IBeeKernelModule
    {
        public void Load(IBeeKernel kernel)
        {
            kernel.Register<IConfigStore, InMemoryConfigStore>();
        }
    }
}