using System;
using ByteBee.Framework.Bootstrapping.Abstractions;
using ByteBee.Framework.Configuring.Abstractions;
using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Messaging.Abstractions;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages;

namespace ByteBee.Framework.Tests.Fake.BLL.TodoManager.Impl
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
            messageBus.Register<TodoMessage>(m => Console.Write(m.Id));
        }

        public void Configure(IConfigManager config)
        {
            config.Set(nameof(TodoManagerConfig), nameof(TodoManagerConfig.MinTimeThreshold), 15);
        }
    }
}