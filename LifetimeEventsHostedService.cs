using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace IPG.MPS.TestService
{
    internal class LifetimeEventsHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private EventLog _eventLog = new EventLog("Application");
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LifetimeEventsHostedService(
            ILogger<LifetimeEventsHostedService> logger,
            IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
            _eventLog.Source = "Application";
            _eventLog.WriteEntry("IPG.MPS.TestServce: LifetimeEventHostedService Constructor Executed.", EventLogEntryType.Information);
            log.Info("IPG.MPS.TestServce: LifetimeEventHostedService Constructor Executed.");

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _eventLog.WriteEntry("IPG.MPS.TestServce: LifetimeEventHostedService StartAsync Executed.", EventLogEntryType.Information);

            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);

            log.Info("IPG.MPS.TestServce: LifetimeEventHostedService StartAsync Executed.");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _eventLog.WriteEntry("IPG.MPS.TestServce: LifetimeEventHostedService StopAsync Executed.", EventLogEntryType.Information);
            log.Info("IPG.MPS.TestServce: LifetimeEventHostedService StopAsync Executed.");

            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _eventLog.WriteEntry("IPG.MPS.TestServce: LifetimeEventHostedService OnStarted has been called.", EventLogEntryType.Information);
            log.Info("IPG.MPS.TestServce: LifetimeEventHostedService OnStarted has been called.");

            // Perform post-startup activities here
        }

        private void OnStopping()
        {
            _eventLog.WriteEntry("IPG.MPS.TestServce: LifetimeEventHostedService OnStopping has been called.", EventLogEntryType.Information);
            log.Info("IPG.MPS.TestServce: LifetimeEventHostedService OnStopping has been called.");

            // Perform on-stopping activities here
        }

        private void OnStopped()
        {
            _eventLog.WriteEntry("IPG.MPS.TestServce: LifetimeEventHostedService OnStopped has been called.", EventLogEntryType.Information);
            log.Info("IPG.MPS.TestServce: LifetimeEventHostedService OnStopped has been called.");

            // Perform post-stopped activities here
        }
    }
}
