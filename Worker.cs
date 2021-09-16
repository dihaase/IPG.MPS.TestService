using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace IPG.MPS.TestService
{
    public class Worker : BackgroundService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                string message = "IPG.MPS.TestServce: ExecuteAsync Worker Thread Executed.";
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(message, EventLogEntryType.Information);
                }
                log.Info(message);
                await Task.Delay(15000, stoppingToken);
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            string message = "IPG.MPS.TestServce: StartAsync Worker Thread Executed.";
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
            log.Info(message);
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            string message = "IPG.MPS.TestServce: StopAsync Worker Thread Executed.";
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
            log.Info(message);
            return base.StopAsync(cancellationToken);
        }

        private void OnStarted()
        {
        }

    }

    }
