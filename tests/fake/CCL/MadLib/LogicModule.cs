using ByteBee.Framework.Fake.BLL.TodoManager.Impl;
using ByteBee.Framework.Injecting.Contract;

namespace ByteBee.Framework.Fake.CCL.MadLib
{
    public class LogicModule : IBeeKernelModule
    {
        public void Load(IBeeKernel kernel)
        {
            kernel.RegisterLifecycle<TodoManagerLifecycle>();
        }
    }
}