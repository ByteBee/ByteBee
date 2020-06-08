using ByteBee.Framework.Abstractions.Logging.DataClasses;

namespace ByteBee.Framework.Abstractions.Logging
{
    public interface ILogPopulator
    {
        void Populate(LogMessage logMessage);
    }
}