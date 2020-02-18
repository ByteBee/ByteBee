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

            kernel.RegisterConfig<TodoManagerConfig>();
        }

        public void Subscribe(IMessageBus messageBus)
        {
        }

        public void Configure(IConfiguration config)
        {
            config.Set(nameof(TodoManagerConfig), nameof(TodoManagerConfig.MinTimeThreshold), 15);
        }
    }
}