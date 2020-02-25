using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Impl;

namespace ByteBee.Framework.Tests.Fake.CCL.MadLib
{
    public sealed class LogicModule : IBeeKernelModule
    {
        public void Load(IBeeKernel kernel)
        {
            kernel.RegisterLifecycle<TodoManagerLifecycle>();
        }
    }
}