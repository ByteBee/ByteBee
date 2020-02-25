namespace ByteBee.Framework.Configuring.Abstractions
{
    public interface IConfigStore
    {
        void Save(IConfigManager source);
        void Load(IConfigManager source);
    }
}