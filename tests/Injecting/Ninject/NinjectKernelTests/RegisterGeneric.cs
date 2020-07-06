using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Abstractions;
using ByteBee.Framework.Tests.Stubbing.Logic.TodoManager.Concrete;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Injecting.Ninject.NinjectKernelTests
{
    public sealed partial class NinjectKernelTest
    {
        [Test]
        public void RegisterGeneric_()
        {
            _kernel.Register<ITodoManager, TodoManager>();

            var todoManager = _kernel.Resolve<ITodoManager>();

            todoManager.Should().BeOfType(typeof(TodoManager));
        }
    }
}