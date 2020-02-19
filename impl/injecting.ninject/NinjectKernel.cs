using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Configuring.Contract;
using ByteBee.Framework.Injecting.Contract;
using Ninject;
using Ninject.Modules;

namespace ByteBee.Framework.Injecting.Impl.Ninject
{
    // ReSharper disable once ClassNeverInstantiated.Global
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
            _kernel.Bind<TContract>().To<TImpl>();
        }

        public void RegisterToSelf<TImpl>()
        {
            _kernel.Bind<TImpl>().ToSelf().InSingletonScope();
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

        public TContract Resolve<TContract>()
        {
            return _kernel.Get<TContract>();
        }
    }
}