using System;
using ByteBee.Framework.Messaging.Abstractions;
using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Abstractions;
using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Abstractions.Messages;

namespace ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Concrete
{
    public class TodoManager : ITodoManager
    {
        private IMessageBus _messageBus;

        public TodoManager(IMessageBus messageBus)
        {
            _messageBus = messageBus;
        }

        public void CreateTask()
        {
            Console.WriteLine("simulate: task creation");

            _messageBus.Publish<TodoMessage>();
        }
    }
}