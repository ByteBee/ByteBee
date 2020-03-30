namespace ByteBee.Framework.Abstractions.Injecting
{
    public interface IBeeKernelModule
    {
        void Load(IBeeKernel kernel);
    }
}