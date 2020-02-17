using System.Collections.Generic;
using ByteBee.Framework.AppConstructing.Contract;
using ByteBee.Framework.AppConstructing.Impl;
using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Fake.BLL.TodoManager.Impl;
using ByteBee.Framework.Fake.CCL.MadLib;
using ByteBee.Framework.Injecting.Contract;
using ByteBee.Framework.Injecting.Impl.Ninject;
using ByteBee.Framework.Messaging.Contract;
using FluentAssertions;
using NUnit.Framework;

namespace ByteBee.Framework.AppConstructing.Tests.Integration
{
    [TestFixture]
    public sealed class ConstructAppTests
    {
        [Test]
        public void KernelInstantiated()
        {
            IBeeKernel kernel = null;

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>(k => kernel = k);

            kernel.Should().NotBeNull()
                .And.BeOfType<NinjectKernel>();
        }

        [Test]
        public void BootstrapperInstantiated()
        {
            IList<ILifecycle> components = new List<ILifecycle>();

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>(new LogicModule())
                .AggregateBootstrapper(components.Add);

            components.Count.Should().Be(1);
        }

        [Test]
        public void ConfigInstantiated()
        {
            TodoManagerConfig config = null;

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>()
                .AggregateBootstrapper()
                .AggregateConfiguration((cf, cs) =>
                {
                    config = cf.Get<TodoManagerConfig>();
                });

            config.Should().NotBeNull();
        }

        [Test]
        public void MessageBusInstantiated()
        {
            IMessageBus bus = null;

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>()
                .AggregateBootstrapper()
                .SkipConfiguration()
                .AggregateMessageBus(m => bus = m);

            bus.Should().NotBeNull();
        }
    }
}