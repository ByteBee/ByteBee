using System;
using System.Collections;
using System.Collections.Generic;
using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Injecting.Contract;
using Ninject;
using Ninject.Modules;

namespace ByteBee.Framework.Injecting.Impl.Ninject
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

        public void Register<TContract, TImpl>() where TImpl : TContract
        {
            _kernel.Bind<TContract>().To<TImpl>().InSingletonScope();
        }

        public void RegisterToSelf<TImpl>()
        {
            _kernel.Bind<TImpl>().ToSelf().InSingletonScope();
        }

        public void RegisterToObject<TObject>(TObject service)
        {
            _kernel.Bind<TObject>().ToConstant(service).InSingletonScope();
        }

        public void RegisterLifecycle<TLifecycle>() where TLifecycle : class
        {
            _kernel.Bind<ILifecycle>().To(typeof(TLifecycle)).InSingletonScope();
        }

        public void RegisterConfig<TConfig>()
        {
            _kernel.Bind<TConfig>()
                .ToMethod(ctx => ctx.Kernel.Get<IConfigObjectProvider>().Get<TConfig>())
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
    }
}