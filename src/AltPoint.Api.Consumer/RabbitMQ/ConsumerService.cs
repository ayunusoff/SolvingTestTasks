using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace AltPoint.Api.Consumer.RabbitMQ
{
    public class ConsumerService : IDisposable
    {
        private readonly IModel _model;
        private readonly IConnection _connection;
        public ConsumerService(RabbitListener rabbitListener)
        {
            _connection = rabbitListener.CreateChannel();
            _model = _connection.CreateModel();
            _model.QueueDeclare(_queueName, exclusive: false);
        }
        const string _queueName = "client";
        public async Task ReadMessages()
        {
            var consumer = new AsyncEventingBasicConsumer(_model);
            consumer.Received += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var text = System.Text.Encoding.UTF8.GetString(body);
                Console.WriteLine(text);
                await Task.CompletedTask;
                _model.BasicAck(ea.DeliveryTag, false);
            };
            _model.BasicConsume(_queueName, false, consumer);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_model.IsOpen)
                _model.Close();
            if (_connection.IsOpen)
                _connection.Close();
        }
    }
}