using System;
using ByteBee.Framework.Bootstrapping.Contract;

namespace ByteBee.Framework.AppConstructing.Contract
{
    public interface IBootstrapperConstructor
    {
        //IConfigConstructor SkipBootstrapper();
        IConfigConstructor AggregateBootstrapper();
        IConfigConstructor AggregateBootstrapper(Action<ILifecycle> lifecycleCallback);
    }
}