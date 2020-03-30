using System;
using System.Collections.Generic;
using ByteBee.Framework.Abstractions.Bootstrapping;
using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;
using ByteBee.Framework.Abstractions.Messaging;

namespace ByteBee.Framework.Abstractions.AppConstructing
{
    public interface IAppConstructor
    {
        IAppConstructor AggregateKernel(IBeeKernel kernel);
        IAppConstructor AggregateKernel(IBeeKernel kernel, IEnumerable<IBeeKernelModule> modules);
        IAppConstructor AggregateKernel<TKernel>(IEnumerable<IBeeKernelModule> modules) where TKernel : IBeeKernel;
        IAppConstructor AggregateKernel<TKernel>(Action<IBeeKernel> kernelCallback) where TKernel : IBeeKernel;
        IAppConstructor AggregateKernel<TKernel>(IEnumerable<IBeeKernelModule> modules, Action<IBeeKernel> kernelCallback) where TKernel : IBeeKernel;

        IAppConstructor AggregateBootstrapper();
        IAppConstructor AggregateBootstrapper(Action<IComponentActivator> lifecycleCallback);

        IAppConstructor AggregateConfiguration();
        IAppConstructor AggregateConfiguration(Action<IConfigManager> configCallback);

        IAppConstructor AggregateMessageBus();
        IAppConstructor AggregateMessageBus(Action<IMessageBus> messageBusCallback);
    }
}