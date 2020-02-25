using System;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract;

namespace ByteBee.Framework.Tests.Fake.BLL.TodoManager.Impl
{
    public class TodoManager : ITodoManager
    {
        public void CreateTask()
        {
            Console.WriteLine("simulate: task creation");
        }
    }
}