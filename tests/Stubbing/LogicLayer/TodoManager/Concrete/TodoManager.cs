using System;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Abstractions;

namespace ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Concrete
{
    public class TodoManager : ITodoManager
    {
        public void CreateTask()
        {
            Console.WriteLine("simulate: task creation");
        }
    }
}