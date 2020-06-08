using System;
using System.Collections.Generic;
using ByteBee.Framework.Abstractions.Logging;
using ByteBee.Framework.Abstractions.Logging.DataClasses;

namespace ByteBee.Logging
{
    public class BeeLogger : ILogger
    {
        private readonly IEnumerable<ILogPopulator> _populators;
        private bool _isTurnedOff;

        public BeeLogger()
        {
            _populators = new ILogPopulator[0];
        }

        public BeeLogger(IEnumerable<ILogPopulator> populators)
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
                foreach (ILogPopulator populator in _populators)
                {
                    populator.Populate(message);
                }
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
