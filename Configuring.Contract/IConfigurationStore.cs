namespace ByteBee.Framework.Configuring.Contract
{
    public interface IConfigurationStore
    {
        void Save(IConfigurationSource source);
        IConfigurationSource Load();
    }
}