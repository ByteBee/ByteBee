using System;
using ByteBee.Framework.Abstractions.Logging;
using ByteBee.Framework.Abstractions.Logging.DataClasses;
using NLog;
using ILogger = NLog.ILogger;

namespace ByteBee.Framework.Logging.NLog
{
    public sealed class NLogPopulator : ILogPopulator
    {
        private readonly ILogger _inner;

        public NLogPopulator(ILogger nlog)
        {
            _inner = nlog;
        }

        public void Populate(LogMessage msg)
        {
            LogLevel logLevel = ConvertLogLevels(msg.Severity);
            _inner.Log(logLevel, msg.Exception, msg.Message);
        }

        private LogLevel ConvertLogLevels(LogSeverity severity)
        {
            switch (severity)
            {
                case LogSeverity.Trace: return LogLevel.Trace;
                case LogSeverity.Debug: return LogLevel.Debug;
                case LogSeverity.Info: return LogLevel.Info;
                case LogSeverity.Warn: return LogLevel.Warn;
                case LogSeverity.Error: return LogLevel.Error;
                case LogSeverity.Fatal: return LogLevel.Fatal;
                default:
                    throw new ArgumentOutOfRangeException(nameof(severity), severity, null);
            }
        }
    }
}
