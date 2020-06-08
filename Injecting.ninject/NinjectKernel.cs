using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using ByteBee.Framework.Abstractions.Bootstrapping;
using ByteBee.Framework.Abstractions.Configuring;
using ByteBee.Framework.Abstractions.Injecting;

namespace ByteBee.Framework.Injecting.Ninject
{
    public sealed class NinjectKernel : IBeeKernel
    {
        private readonly IKernel _kernel;
        private readonly IBeeKernelModule[] _beeModules;
        private readonly INinjectModule[] _ninjectModules;

        public NinjectKernel()
        {
            _kernel = new StandardKernel();
        }

        public NinjectKernel(INinjectModule[] modules)
        {
            _kernel = new StandardKernel(modules);
            _ninjectModules = modules;
        }

        public NinjectKernel(IBeeKernelModule[] modules)
        {
            _kernel = new StandardKernel();
            _beeModules = modules;

            foreach (IBeeKernelModule module in modules)
            {
                module.Load(this);
            }
        }

        public NinjectKernel(INinjectModule[] ninjectModules, IBeeKernelModule[] beeModules)
        {
            _kernel = new StandardKernel(ninjectModules);
            _ninjectModules = ninjectModules;
            _beeModules = beeModules;

            foreach (IBeeKernelModule module in beeModules)
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

        public void RegisterComponent<TComponent>() where TComponent : IComponentActivator
        {
            _kernel.Bind<IComponentActivator>().To(typeof(TComponent)).InSingletonScope();
        }

        public void RegisterConfig<TConfig>()
        {
            _kernel.Bind<TConfig>()
                .ToMethod(ctx =>
                {
                    var configProvider = ctx.Kernel.Get<IConfigProvider>();
                    return configProvider.Get<TConfig>();
                })
                .InSingletonScope();
        }

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

        public void Dispose()
        {
            for (int i = 0; i < _ninjectModules?.Length; i++)
            {
                _ninjectModules[i] = null;
            }

            for (int i = 0; i < _beeModules?.Length; i++)
            {
                _beeModules[i] = null;
            }

            _kernel?.Dispose();
        }
    }
}