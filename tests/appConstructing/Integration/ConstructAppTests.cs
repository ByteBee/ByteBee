using System.Collections.Generic;
using ByteBee.Framework.Abstractions.Bootstrapping;
using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;
using ByteBee.Framework.Abstractions.Messaging;
using ByteBee.Framework.AppConstructing;
using ByteBee.Framework.Bootstrapping;
using ByteBee.Framework.Configuring;
using ByteBee.Framework.Injecting.Ninject;
using ByteBee.Framework.Messaging;
using ByteBee.Framework.Tests.Fake.CCL.MadLib;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Abstractions.Messages;
using ByteBee.Framework.Tests.Stubbing.LogicLayer.TodoManager.Concrete;
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
                .AggregateKernel<NinjectKernel>(Aggregator.Modules, kernel =>
                {
                    kernel.Register<IBootstrapper, StandardBootstrapper>();
                })
                .AggregateBootstrapper(components.Add);

            components.Count.Should().Be(1);
        }

        [Test]
        public void ConfigInstantiated()
        {
            int minTimeThreshold = 0;

            ConstructApp.Default
                .AggregateKernel<NinjectKernel>(Aggregator.Modules, kernel =>
                {
                    kernel.Register<IBootstrapper, StandardBootstrapper>();
                    kernel.Register<IConfigManager, StandardConfigManager>();
                })
                .AggregateBootstrapper()
                .AggregateConfiguration(cfg =>
                {
                    minTimeThreshold = cfg.Get<int>(
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
                    kernel.Register<IBootstrapper, StandardBootstrapper>();
                    kernel.Register<IMessageBus, StandardMessageBus>();

                    kernel.RegisterComponent<TodoManagerActivator>();
                })
                .AggregateBootstrapper()
                .AggregateMessageBus(m => bus = m);

            bus.Publish<TodoMessage>();

            bus.Should().NotBeNull();
        }

        [Test]
        public void Aggregate_KernelConfigBusBootstrapper_NoError()
        {
            ConstructApp.Default
                .AggregateKernel<NinjectKernel>(Aggregator.Modules, kernel =>
                {
                    kernel.Register<IConfigManager, StandardConfigManager>();
                    kernel.Register<IBootstrapper, StandardBootstrapper>();
                    kernel.Register<IMessageBus, StandardMessageBus>();
                })
                .AggregateConfiguration(cfg =>
                {
                    //string rootPath = rootPathProvider.GetRootPath();
                    cfg.Set("path", "root", "/home/root");
                })
                .AggregateMessageBus(bus =>
                {
                    bus.BreakOnException = true;
                    //bus.SetResolverCallback(t => _kernel.Resolve(t));
                })
                .AggregateBootstrapper();
        }
    }
}