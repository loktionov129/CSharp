using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class GracePeriodManagerService : BackgroundService
    {
        private readonly ILogger<GracePeriodManagerService> _logger;

        public GracePeriodManagerService(ILogger<GracePeriodManagerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            System.Console.WriteLine($"GracePeriodManagerService is starting.");
            _logger.LogDebug($"GracePeriodManagerService is starting.");

            stoppingToken.Register(() =>
            {
                System.Console.WriteLine($" GracePeriod background task is stopping.");
                _logger.LogDebug($" GracePeriod background task is stopping.");
            });

            while (!stoppingToken.IsCancellationRequested)
            {
                System.Console.WriteLine($"GracePeriod task doing background work.");
                _logger.LogDebug($"GracePeriod task doing background work.");
                await Task.Delay(2000, stoppingToken);
            }

            System.Console.WriteLine($"GracePeriod background task is stopping.");
            _logger.LogDebug($"GracePeriod background task is stopping.");

        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"GracePeriod background task is stopping.");
            System.Console.WriteLine($"GracePeriod background task is stopping.");
            await Task.Delay(0);
        }
    }
}
