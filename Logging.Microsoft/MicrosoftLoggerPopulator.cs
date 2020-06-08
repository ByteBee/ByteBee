using System;
using ByteBee.Framework.Abstractions.Logging;
using ByteBee.Framework.Abstractions.Logging.DataClasses;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace ByteBee.Framework.Logging.Microsoft
{
    public sealed class MicrosoftLoggerPopulator : ILogPopulator
    {
        private readonly ILogger _inner;

        public MicrosoftLoggerPopulator(ILogger msLogger)
        {
            _inner = msLogger;
        }

        public void Populate(LogMessage msg)
        {
            LogLevel logLevel = ConvertLogLevels(msg.Severity);

            if (msg.Exception == null)
            {
                _inner.Log(logLevel, msg.Message);
            }
            else
            {
                _inner.Log(logLevel, msg.Exception, msg.Message);
            }
        }

        private LogLevel ConvertLogLevels(LogSeverity severity)
        {
            switch (severity)
            {
                case LogSeverity.Trace: return LogLevel.Trace;
                case LogSeverity.Debug: return LogLevel.Debug;
                case LogSeverity.Info: return LogLevel.Information;
                case LogSeverity.Warn: return LogLevel.Warning;
                case LogSeverity.Error: return LogLevel.Error;
                case LogSeverity.Fatal: return LogLevel.Critical;
                default:
                    throw new ArgumentOutOfRangeException(nameof(severity), severity, null);
            }
        }
    }
}
