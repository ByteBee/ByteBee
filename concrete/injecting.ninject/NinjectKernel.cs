using ByteBee.Framework.Injecting.Abstractions;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;

namespace ByteBee.Framework.Injecting.Ninject
{
    public sealed class NinjectKernel : IBeeKernel
    {
        private readonly IKernel _kernel;

        public NinjectKernel()
        {
            _kernel = new StandardKernel();
        }

        public NinjectKernel(params INinjectModule[] modules)
        {
            _kernel = new StandardKernel(modules);
        }

        public NinjectKernel(params IBeeKernelModule[] modules)
        {
            _kernel = new StandardKernel();

            foreach (IBeeKernelModule module in modules)
            {
                module.Load(this);
            }
        }

        public void Register<TContract, TImpl>() where TImpl : TContract
        {
            _kernel.Bind<TContract>().To<TImpl>().InSingletonScope();
        }

        public void Register(Type abstraction, Type concrete)
        {
            _kernel.Bind(abstraction).To(concrete);
        }

        public void RegisterToSelf<TImpl>()
        {
            _kernel.Bind<TImpl>().ToSelf().InSingletonScope();
        }

        public void RegisterToObject<TObject>(TObject service)
        {
            _kernel.Bind<TObject>().ToConstant(service).InSingletonScope();
        }

        public void RegisterToMethod<TAbstraction>(Func<IBeeKernel, TAbstraction> callback)
        {
            _kernel.Bind<TAbstraction>().ToMethod(ctx =>
            {
                return callback(this);
            });
        }

        //public void RegisterComponent<TComponent>() where TComponent : class
        //{
        //    _kernel.Bind<IComponentActivator>().To(typeof(TComponent)).InSingletonScope();
        //}

        //public void RegisterConfig<TConfig>()
        //{
        //    _kernel.Bind<TConfig>()
        //        .ToMethod(ctx =>
        //        {
        //            var configProvider = ctx.Kernel.Get<IConfigObjectProvider>();
        //            return configProvider.Get<TConfig>();
        //        })
        //        .InSingletonScope();
        //}

        public void RegisterObject(object service)
        {
            _kernel.Inject(service);
        }

        public TContract Resolve<TContract>()
        {
            return _kernel.Get<TContract>();
        }

        public object Resolve(Type service)
        {
            return _kernel.Get(service);
        }

        public IEnumerable<TContract> ResolveAll<TContract>()
        {
            return _kernel.GetAll<TContract>();
        }

        public IEnumerable<object> ResolveAll(Type services)
        {
            return _kernel.GetAll(services);
        }
    }
}