using AnaliseVendasApplication.Interface;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnaliseVendasApplication.Implementation
{
    public class SalesHostedService : ISalesHostedService, IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ISalesApplication _salesApplication;
        private readonly ILogger _logger;

        public SalesHostedService(ISalesApplication salesApplication, ILogger<SalesHostedService> logger)
        {
            _salesApplication = salesApplication;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Process, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Process(object state)
        {
            _salesApplication.Process();
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
