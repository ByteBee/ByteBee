using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Injecting.Ninject;
using ByteBee.Framework.Messaging.Abstractions;
using ByteBee.Framework.Tests.Stubbing.Infrastructure.MadLib;
using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Abstractions;

namespace ByteBee.Framework.Tests.Stubbing.Ui
{
    public class Program
    {
        public static void Main()
        {
            IKernel kernel = new NinjectKernel(new Aggregator().Modules);
            var bus = kernel.Resolve<IMessageBus>();
            bus.SetResolverCallback(t => kernel.Resolve(t));

            var todo = kernel.Resolve<ITodoManager>();
            todo.CreateTask();
        }
    }
}