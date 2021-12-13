using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;

namespace BookStoreSelling.API.Infrastructure
{
    public class InitDataJob : IJob
    {
        private readonly ILogger<InitDataJob> _logger;
        public InitDataJob(ILogger<InitDataJob> logger)
        {
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("This is the job that reads xml file from email to init data to the database");
            return Task.CompletedTask;
        }
    }
}