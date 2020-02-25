namespace ByteBee.Framework.Configuring.Contract
{
    public interface IConfigStore
    {
        void Save(IConfiguration source);
        void Load(IConfiguration source);
    }
}