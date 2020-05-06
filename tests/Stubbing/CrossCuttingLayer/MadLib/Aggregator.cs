using ByteBee.Framework.Abstractions.Injecting;

namespace ByteBee.Framework.Tests.Fake.CCL.MadLib
{
    public static class Aggregator
    {
        public static readonly IBeeKernelModule[] Modules = new IBeeKernelModule[]
        {
            new InfrastructureModule(),

            new LogicModule(),
        };
    }
}