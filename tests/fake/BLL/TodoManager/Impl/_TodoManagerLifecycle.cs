using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Fake.BLL.TodoManager.Contract;
using ByteBee.Framework.Injecting.Contract;
using ByteBee.Framework.Messaging.Contract;

namespace ByteBee.Framework.Fake.BLL.TodoManager.Impl
{
    public class TodoManagerLifecycle : ILifecycle
    {
        public void Activate()
        {
        }

        public void Deactivate()
        {
        }

        public void Register(IBeeKernel kernel)
        {
            kernel.Register<ITodoManager, TodoManager>();
        }

        public void Subscribe(IMessageBus messageBus)
        {
        }

        public void Configure(IConfigFactory config)
        {
        }
    }
}