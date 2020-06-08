﻿using System;
using ByteBee.Framework.Abstractions.Bootstrapping;
using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;
using ByteBee.Framework.Abstractions.Messaging;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Abstractions;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Abstractions.Messages;

namespace ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Concrete
{
    public class TodoManagerActivator : IComponentActivator
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