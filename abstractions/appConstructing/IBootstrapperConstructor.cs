using System;
using ByteBee.Framework.Bootstrapping.Abstractions;

namespace ByteBee.Framework.AppConstructing.Abstractions
{
    public interface IBootstrapperConstructor
    {
        //IConfigConstructor SkipBootstrapper();
        IConfigConstructor AggregateBootstrapper();
        IConfigConstructor AggregateBootstrapper(Action<ILifecycle> lifecycleCallback);
    }
}