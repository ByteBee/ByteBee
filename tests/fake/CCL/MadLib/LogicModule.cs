using ByteBee.Framework.Abstractions.Injecting;
using ByteBee.Framework.Bootstrapping;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Impl;

namespace ByteBee.Framework.Tests.Fake.CCL.MadLib
{
    public sealed class LogicModule : IBeeKernelModule
    {
        public void Load(IBeeKernel kernel)
        {
            kernel.RegisterComponent<TodoManagerActivator>();
        }
    }
}