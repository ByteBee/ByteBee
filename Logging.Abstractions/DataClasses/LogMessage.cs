using System;

namespace ByteBee.Framework.Logging.Abstractions.DataClasses
{
    public class LogMessage
    {
        public DateTime TimeOfDay { get; }
        public LogSeverity Severity { get; }
        public string Message { get; }
        public Exception Exception { get; }

        public LogMessage(DateTime timeOfDay, LogSeverity severity, string message, Exception exception)
        {
            TimeOfDay = timeOfDay;
            Severity = severity;
            Message = message;
            Exception = exception;
        }

        public LogMessage(LogSeverity severity, string message, Exception exception)
            : this(DateTime.Now, severity, message, exception)
        {
        }

        public LogMessage(DateTime timeOfDay, LogSeverity severity, string message)
            : this(timeOfDay, severity, message, null)
        {
        }

        public LogMessage(LogSeverity severity, string message)
            : this(severity, message, null)
        {
        }
    }
}