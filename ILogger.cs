using System;

namespace IPG.MPS.TestService
{
    public enum LogSeverity
    {
        Debug,
        Info,
        Warning,
        Error,
        Fatal
    }

    /// <summary>
    /// Provide Logging Functionality
    /// </summary>
    public interface ILogger
    {
        void Log(LogSeverity logSeverity, string message);

        void Log(LogSeverity logSeverity, string message, Exception exception);

    }
}