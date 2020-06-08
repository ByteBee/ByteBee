using ByteBee.Framework.Abstractions.AppConstructing;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class StandardAppConstructor : IAppConstructor
    {
        public StandardAppConstructor()
        {
        }
        
        public void Dispose()
        {
            DisposeConfiguration();
            DisposeMessageBus();
            DisposeBootstrapper();
            DisposeKernel();
        }
    }
}