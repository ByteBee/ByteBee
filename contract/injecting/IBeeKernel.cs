namespace ByteBee.Framework.Injecting.Contract
{
    public interface IBeeKernel
    {
        void Register<TContract, TImpl>() where TImpl : TContract;
        void RegisterLifecycle<TLifecycle>() where TLifecycle : class;

        TContract Resolve<TContract>();
    }
}