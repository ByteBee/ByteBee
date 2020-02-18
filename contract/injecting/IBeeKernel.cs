namespace ByteBee.Framework.Injecting.Contract
{
    public interface IBeeKernel
    {
        void Register<TContract, TImpl>() where TImpl : TContract;
        void RegisterToSelf<TImpl>();
        void RegisterLifecycle<TLifecycle>() where TLifecycle : class;
        void RegisterConfig<TConfig>();

        TContract Resolve<TContract>();
    }
}