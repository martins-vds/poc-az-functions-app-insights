using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Contoso
{
    public class ServiceBusTrigger
    {
        private readonly ILogger<ServiceBusTrigger> _log;

        public ServiceBusTrigger(ILogger<ServiceBusTrigger> log)
        {
            _log = log;
        }

        [FunctionName("ServiceBusTrigger")]
        public Task Run([ServiceBusTrigger("myqueue", Connection = "ServiceBusConnectionString")] string myQueueItem)
        {
            _log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            return Task.CompletedTask;
        }
    }
}
