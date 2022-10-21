using Quartz;
using Registro_de_Ponto_CTEDS.Interfaces;

namespace Registro_de_Ponto_CTEDS.Services
{
    [DisallowConcurrentExecution]
    public class CronJob : IJob
    {
        private IClock _clockRepository;
        private readonly ILogger<CronJob> _logger;
        public CronJob(IClock clock, ILogger<CronJob> logger)
        {
            _clockRepository = clock;
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var message = _clockRepository.GetMissWorkDay();
            _logger.LogInformation(message);
            return Task.CompletedTask;
           
        }
    }
}
