using System;
using System.Collections.Generic;

namespace ByteBee.Framework.Injecting.Abstractions
{
    public interface IKernel : IDisposable
    {
        void Register<TAbstraction, TConcrete>() where TConcrete : TAbstraction;
        void Register(Type abstraction, Type concrete);
        void RegisterToSelf<TConcrete>();
        
        void RegisterToObject<TObject>(TObject service);
        void RegisterToMethod<TAbstraction>(Func<IKernel, TAbstraction> callback);
        void RegisterObject(object service);

        TContract Resolve<TContract>();
        object Resolve(Type service);
        IEnumerable<TAbstraction> ResolveAll<TAbstraction>();
        IEnumerable<object> ResolveAll(Type services);

        void RegisterModule<TModule>() where TModule : IKernelModule;
    }
}