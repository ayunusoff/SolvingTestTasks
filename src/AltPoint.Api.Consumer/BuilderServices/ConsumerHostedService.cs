using AltPoint.Api.Consumer.RabbitMQ;

namespace AltPoint.Api.Consumer.BuilderServices
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly ConsumerService _consumerService;

        public ConsumerHostedService(ConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _consumerService.ReadMessages();
                }
                catch (Exception ex)
                {
                    // обработка ошибки однократного неуспешного выполнения фоновой задачи
                }

                await Task.Delay(5000);
            }
        }
    }
}
