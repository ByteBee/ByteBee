using System.Collections.Generic;
using ByteBee.Framework.AppConstructing.Contract;
using ByteBee.Framework.AppConstructing.Impl;
using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Fake.BLL.TodoManager.Contract.Messages;
using ByteBee.Framework.Fake.BLL.TodoManager.Impl;
using ByteBee.Framework.Fake.CCL.MadLib;
using ByteBee.Framework.Injecting.Contract;
using ByteBee.Framework.Injecting.Impl.Ninject;
using ByteBee.Framework.Messaging.Contract;
using FluentAssertions;
using FluentAssertions.Execution;
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
        public void KernelUsing()
        {
            IBeeKernel kernel = new NinjectKernel();

            ConstructApp.Default
                .AggregateKernel(kernel);

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
            int minTimeThreshold = 0;

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>(new LogicModule())
                .AggregateBootstrapper()
                .AggregateConfiguration(cs =>
                {
                    minTimeThreshold = cs.Get<int>(
                        nameof(TodoManagerConfig),
                        nameof(TodoManagerConfig.MinTimeThreshold));
                });

            using (new AssertionScope())
            {
                minTimeThreshold.Should().Be(15);
            }
        }

        [Test]
        public void MessageBusInstantiated()
        {
            IMessageBus bus = null;

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>(kernel =>
                {
                    kernel.RegisterLifecycle<TodoManagerLifecycle>();
                })
                .AggregateBootstrapper()
                .SkipConfiguration()
                .AggregateMessageBus(m => bus = m);

            bus.Publish<TodoMessage>();

            bus.Should().NotBeNull();
        }
    }
}