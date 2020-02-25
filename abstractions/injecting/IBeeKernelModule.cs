namespace ByteBee.Framework.Injecting.Abstractions
{
    public interface IBeeKernelModule
    {
        void Load(IBeeKernel kernel);
    }
}