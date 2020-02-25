using ByteBee.Framework.Injecting.Abstractions;

namespace ByteBee.Framework.Tests.Fake.CCL.MadLib
{
    public class Aggregator
    {
        public IBeeKernelModule[] Modules = new IBeeKernelModule[]
        {
            new InfrastructureModule(),

            new LogicModule(),
        };
    }
}