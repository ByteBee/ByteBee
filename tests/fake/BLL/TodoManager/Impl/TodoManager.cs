using System;
using ByteBee.Framework.Fake.BLL.TodoManager.Contract;

namespace ByteBee.Framework.Fake.BLL.TodoManager.Impl
{
    public class TodoManager : ITodoManager
    {
        public void CreateTask()
        {
            Console.WriteLine("simulate: task creation");
        }
    }
}