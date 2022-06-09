using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DISample.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IHostBuilder builder = 
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices(services =>
                    {
                        services.AddHostedService<SampleHostedService>();
                    });
            
            builder.ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                });

            builder.Build()
            .RunAsync();
        }
    }

    internal class SampleHostedService : IHostedService
    {
        private readonly ILogger<SampleHostedService> _logger;

        public SampleHostedService(ILogger<SampleHostedService> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () => 
            { 

                _logger.LogInformation("==> Start long running task.");
                
                await Task.Delay(5000, cancellationToken);

                _logger.LogInformation("==> Complete long running task.");

            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
