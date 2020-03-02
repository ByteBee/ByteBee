using System;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages;

namespace ByteBee.Framework.Tests.Fake.BLL.TodoManager.Impl
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