using ByteBee.Framework.Abstractions.Logging;
using ByteBee.Framework.Abstractions.Logging.DataClasses;
using log4net;

namespace ByteBee.Framework.Logging.log4net
{
    public sealed class Log4NetPopulator : ILogPopulator
    {
        private readonly ILog _inner;

        public Log4NetPopulator(ILog log4net)
        {
            _inner = log4net;
        }

        public void Populate(LogMessage msg)
        {
            switch (msg.Severity)
            {
                case LogSeverity.Trace:
                    _inner.Debug(msg.Message, msg.Exception);
                    break;

                case LogSeverity.Debug:
                    _inner.Debug(msg.Message, msg.Exception);
                    break;

                case LogSeverity.Info:
                    _inner.Info(msg.Message, msg.Exception);
                    break;

                case LogSeverity.Warn:
                    _inner.Warn(msg.Message, msg.Exception);
                    break;

                case LogSeverity.Error:
                    _inner.Error(msg.Message, msg.Exception);
                    break;

                case LogSeverity.Fatal:
                    _inner.Fatal(msg.Message, msg.Exception);
                    break;
            }
        }
    }
}
