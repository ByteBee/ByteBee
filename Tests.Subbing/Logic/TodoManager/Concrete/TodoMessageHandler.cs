using System;
using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Abstractions.Messages;

namespace ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Concrete
{
    public class TodoMessageHandler
    {
        public void Create(TodoMessage message)
        {
            Console.WriteLine(message.Id);
            message.IsHandled = true;
            message.HandleCount++;
        }
    }
}