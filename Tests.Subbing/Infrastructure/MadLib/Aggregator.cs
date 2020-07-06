using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Concrete;

namespace ByteBee.Framework.Tests.Stubbing.Infrastructure.MadLib
{
    public class Aggregator
    {
        public readonly IKernelModule[] Modules = new IKernelModule[]
        {
            new InfrastructureModule(),

            new TodoManagerModule(),
        };
    }
}