using ByteBee.Framework.Logging.Abstractions.DataClasses;

namespace ByteBee.Framework.Logging.Abstractions
{
    public interface ILogFormatter
    {
        string Format(LogMessage message);
    }
}