namespace ByteBee.Framework.Bootstrapping.Abstractions
{
    public interface IComponentActivator
    {
        void Activate();
        void Deactivate();
    }
}