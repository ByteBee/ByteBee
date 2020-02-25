namespace ByteBee.Framework.Configuring.Abstractions
{
    public interface IConfigStore
    {
        void Initialize(IConfigManager configManager);
        void Save();
        void Load();
    }
}