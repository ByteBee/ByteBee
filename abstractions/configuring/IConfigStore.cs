namespace ByteBee.Framework.Abstractions.Configuring
{
    public interface IConfigStore
    {
        void Initialize(IConfigManager configManager);
        void Save();
        void Load();
    }
}