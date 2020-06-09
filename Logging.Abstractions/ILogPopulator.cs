using ByteBee.Framework.Logging.Abstractions.DataClasses;

namespace ByteBee.Framework.Logging.Abstractions
{
    public interface ILogPopulator
    {
        void Populate(LogMessage logMessage);
    }
}