using ByteBee.Framework.Abstractions.Logging;
using ByteBee.Framework.Abstractions.Logging.DataClasses;
using ILogger = Serilog.ILogger;

namespace ByteBee.Framework.Logging
{
    public sealed class SerilogPopulator : ILogPopulator
    {
        private readonly ILogger _inner;

        public SerilogPopulator(ILogger serilog)
        {
            _inner = serilog;
        }

        public void Populate(LogMessage msg)
        {
            switch (msg.Severity)
            {
                case LogSeverity.Trace:
                    _inner.Debug(msg.Exception, msg.Message);
                    break;

                case LogSeverity.Debug:
                    _inner.Debug(msg.Exception, msg.Message);
                    break;

                case LogSeverity.Info:
                    _inner.Information(msg.Exception, msg.Message);
                    break;

                case LogSeverity.Warn:
                    _inner.Warning(msg.Exception, msg.Message);
                    break;

                case LogSeverity.Error:
                    _inner.Error(msg.Exception, msg.Message);
                    break;

                case LogSeverity.Fatal:
                    _inner.Fatal(msg.Exception, msg.Message);
                    break;
            }

        }
    }
}
