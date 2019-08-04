using AnaliseVendasApplication.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnaliseVendasApplication.Implementation
{
    public class SalesHostedService: IHostedService, IDisposable
    {
        private Timer _timer;

        private readonly ILogger _logger;
        public IServiceProvider Services { get; }

        public SalesHostedService(IServiceProvider services, ILogger<SalesHostedService> logger)
        {
            Services = services;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void DoWork(object state)
        {
            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService =
                    scope.ServiceProvider
                        .GetRequiredService<ISalesApplication>();

                scopedProcessingService.Process();
            }
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
