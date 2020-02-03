using ByteBee.Framework.Configuring;
using NUnit.Framework;

namespace ByteBee.Configurating.Tests.Default.ConfigurationSourceTests
{
    [TestFixture]
    public sealed partial class ConfigurationSourceTest
    {
        private StandardConfigurationSource _source;

        [SetUp]
        public void Setup()
        {
            _source = new StandardConfigurationSource();
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}