using ByteBee.Framework.Abstractions.Logging.DataClasses;

namespace ByteBee.Framework.Abstractions.Logging
{
    public interface ILogFormatter
    {
        string Format(LogMessage message);
    }
}