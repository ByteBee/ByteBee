using ByteBee.Framework.Configuring.Contract;

namespace ByteBee.Framework.Configuring.JsonNet
{
    public class JsonNetConfigurationStore : IConfigurationStore
    {
        private IConfigurationSource _source;

        public JsonNetConfigurationStore(IConfigurationSource source)
        {
            _source = source;
        }

        public void Save(IConfigurationSource source)
        {
            _source = source;

            throw new System.NotImplementedException();
        }

        public IConfigurationSource Load()
        {
            throw new System.NotImplementedException();
        }
    }
}