using System;
using ByteBee.Framework.Abstractions.Logging.DataClasses;

namespace ByteBee.Framework.Abstractions.Logging
{
    public interface ILogger
    {
        void TurnOff();
        void TurnOn();

        void Log(LogMessage message);

        void Trace(string message);
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Warn(string message, Exception ex);
        void Error(string message, Exception ex);
        void Fatal(string message, Exception ex);
    }
}