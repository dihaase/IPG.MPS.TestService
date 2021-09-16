using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace IPG.MPS.TestService
{
    public class LoggerManager : ILogger
    {
        ILog mainLog;
        private readonly string logPath;
        private string configPath;

        public LoggerManager()
        {
            var configuration = new FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LoggingConfig.xml"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configuration);
            mainLog = LogManager.GetLogger("MainLogger");
        }

        // Logging functionality happens here
        public void Log(LogSeverity logSeverity, string message)
        {
            mainLog.Info(message);
        }

        public void Log(LogSeverity logSeverity, string message, Exception exception)
        {
            mainLog.Info(message);
        }
    }
}
