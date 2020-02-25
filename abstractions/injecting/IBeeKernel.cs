using System;
using System.Collections.Generic;

namespace ByteBee.Framework.Injecting.Abstractions
{
    public interface IBeeKernel
    {
        void Register<TContract, TImpl>() where TImpl : TContract;
        void RegisterToSelf<TImpl>();
        void RegisterToObject<TObject>(TObject service);
        void RegisterLifecycle<TLifecycle>() where TLifecycle : class;
        void RegisterConfig<TConfig>();
        void RegisterObject(object service);

        TContract Resolve<TContract>();
        object Resolve(Type service);
        IEnumerable<TContract> ResolveAll<TContract>();
        IEnumerable<object> ResolveAll(Type services);
    }
}