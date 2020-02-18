namespace ByteBee.Framework.Configuring.Contract
{
    public interface IConfigStore
    {
        void Save(IConfiguration source);
        IConfiguration Load();
    }
}