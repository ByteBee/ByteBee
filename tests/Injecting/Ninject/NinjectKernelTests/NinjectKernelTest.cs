using ByteBee.Framework.Injecting.Ninject;
using NUnit.Framework;

namespace ByteBee.Framework.Tests.Injecting.Ninject.NinjectKernelTests
{
    [TestFixture]
    public sealed partial class NinjectKernelTest
    {
        private NinjectKernel _kernel;

        [SetUp]
        public void Setup()
        {
            _kernel = new NinjectKernel();
        }
        
        [TearDown]
        public void TearDown()
        {
            _kernel.Dispose();
        }
    }
}