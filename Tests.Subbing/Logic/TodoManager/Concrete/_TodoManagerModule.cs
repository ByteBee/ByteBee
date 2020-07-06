using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Messaging.Abstractions;
using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Abstractions;

namespace ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Concrete
{
    public sealed class TodoManagerModule : IKernelModule
    {
        public void Load(IKernel kernel)
        {
            kernel.Register<IMessageSubscription, TodoMessageSubscriptions>();

            kernel.Register<ITodoManager, TodoManager>();
        }
    }
}