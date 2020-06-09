namespace ByteBee.Framework.Injecting.Abstractions
{
    public interface IKernelModule
    {
        void Load(IKernel kernel);
    }
}