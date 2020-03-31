using System;
using System.Collections.Generic;
using ByteBee.Framework.Abstractions.Bootstrapping;

namespace ByteBee.Framework.Abstractions.Injecting
{
    public interface IBeeKernel
    {
        void Register<TAbstraction, TConcrete>() where TConcrete : TAbstraction;
        void Register(Type abstraction, Type concrete);
        void RegisterToSelf<TConcrete>();
        void RegisterToObject<TObject>(TObject service);
        void RegisterToMethod<TAbstraction>(Func<IBeeKernel, TAbstraction> callback);
        void RegisterObject(object service);

        TContract Resolve<TContract>();
        object Resolve(Type service);
        IEnumerable<TContract> ResolveAll<TContract>();
        IEnumerable<object> ResolveAll(Type services);

        void RegisterComponent<TComponent>() where TComponent : IComponentActivator;
        void RegisterConfig<TConfig>();
    }
}