using System;
using ByteBee.Framework.AppConstructing.Contract;
using ByteBee.Framework.Injecting.Contract;

namespace ByteBee.Framework.AppConstructing.Impl
{
    public sealed partial class ConstructApp : IAppConstructor
    {
        private ConstructApp()
        {
        }

        public static IKernelConstructor Default => new ConstructApp();
    }
}