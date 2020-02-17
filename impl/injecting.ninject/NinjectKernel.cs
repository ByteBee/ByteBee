using ByteBee.Framework.Bootstrapping.Contract;
using ByteBee.Framework.Injecting.Contract;
using Ninject;

namespace ByteBee.Framework.Injecting.Impl.Ninject
{
    public sealed class NinjectKernel : IBeeKernel
    {
        private readonly IKernel _kernel;

        public NinjectKernel()
        {
            _kernel = new StandardKernel();
        }

        public void Register<TContract, TImpl>() where TImpl : TContract
        {
            _kernel.Bind<TContract>().To<TImpl>();
        } 

        public void RegisterLifecycle<TLifecycle>() where TLifecycle : class
        {
            _kernel.Bind<ILifecycle>().To(typeof(TLifecycle)).InSingletonScope();
        }

        public TContract Resolve<TContract>()
        {
            return _kernel.Get<TContract>();
        }
    }
}