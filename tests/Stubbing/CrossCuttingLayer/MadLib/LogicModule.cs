using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Abstractions;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Concrete;

namespace ByteBee.Framework.Tests.Stubbing.CrossCuttingLayer.MadLib
{
    public sealed class LogicModule : IKernelModule
    {
        public void Load(IKernel kernel)
        {
            kernel.Register<ITodoManager, TodoManager>();
        }
    }
}