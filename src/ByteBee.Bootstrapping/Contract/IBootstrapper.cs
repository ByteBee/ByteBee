namespace ByteBee.Framework.Bootstrapping.Contract
{
    public interface IBootstrapper
    {
        void Construct();
        void Destruct();
        void RegisterBindings();
        void Configure();
        void AddSubscriptions();
        void Activate();
        void Deactivate();
    }
}