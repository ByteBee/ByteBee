using System;
using System.Collections.Generic;
using ByteBee.Framework.Logging.Abstractions;
using ByteBee.Framework.Logging.Abstractions.DataClasses;

namespace ByteBee.Framework.Logging
{
    public class BeeLogger : ILogger
    {
        private readonly List<ILogPopulator> _populators;
        private bool _isTurnedOff;

        public BeeLogger() : this(new List<ILogPopulator>())
        {
        }

        public BeeLogger(List<ILogPopulator> populators)
        {
            _populators = populators;
        }
        
        public void TurnOff()
        {
            _isTurnedOff = true;
        }

        public void TurnOn()
        {
            _isTurnedOff = false;
        }

        public void Log(LogMessage message)
        {
            if (_isTurnedOff == false)
            {
                _populators.ForEach(p => p.Populate(message));
            }
        }

        public void Trace(string message)
        {
            Log(new LogMessage(LogSeverity.Trace, message));
        }

        public void Debug(string message)
        {
            Log(new LogMessage(LogSeverity.Debug, message));
        }

        public void Info(string message)
        {
            Log(new LogMessage(LogSeverity.Info, message));
        }

        public void Warn(string message)
        {
            Log(new LogMessage(LogSeverity.Warn, message));
        }

        public void Warn(string message, Exception ex)
        {
            Log(new LogMessage(LogSeverity.Warn, message, ex));
        }

        public void Error(string message, Exception ex)
        {
            Log(new LogMessage(LogSeverity.Error, message, ex));
        }

        public void Fatal(string message, Exception ex)
        {
            Log(new LogMessage(LogSeverity.Fatal, message, ex));
        }
    }
}
