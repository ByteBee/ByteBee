using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;
using ByteBee.Framework.Configuring;

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