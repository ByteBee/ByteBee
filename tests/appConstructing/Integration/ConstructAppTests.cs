using System.Collections.Generic;
using ByteBee.Framework.AppConstructing;
using ByteBee.Framework.Bootstrapping;
using ByteBee.Framework.Bootstrapping.Abstractions;
using ByteBee.Framework.Injecting.Abstractions;
using ByteBee.Framework.Injecting.Ninject;
using ByteBee.Framework.Messaging.Abstractions;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Contract.Messages;
using ByteBee.Framework.Tests.Fake.BLL.TodoManager.Impl;
using ByteBee.Framework.Tests.Fake.CCL.MadLib;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.AppConstructing.Integration
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
            IList<IComponentActivator> components = new List<IComponentActivator>();

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>(new Aggregator().Modules)
                .AggregateBootstrapper(components.Add);

            components.Count.Should().Be(1);
        }

        [Test]
        public void ConfigInstantiated()
        {
            int minTimeThreshold = 0;

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>(new Aggregator().Modules)
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
                    kernel.RegisterComponent<TodoManagerActivator>();
                })
                .AggregateBootstrapper()
                .SkipConfiguration()
                .AggregateMessageBus(m => bus = m);

            bus.Publish<TodoMessage>();

            bus.Should().NotBeNull();
        }
    }
}