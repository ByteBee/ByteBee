using ByteBee.Framework.AppConstructing.Abstractions;

namespace ByteBee.Framework.AppConstructing
{
    public sealed partial class ConstructApp : IAppConstructor
    {
        private ConstructApp()
        {
        }

        public static IKernelConstructor Default => new ConstructApp();
    }
}