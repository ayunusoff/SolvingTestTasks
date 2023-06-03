using AltPoint.Application.Common;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace AltPoint.Infrastructure.RabbitMQ
{
    public class RabbitMQProducer : IProducer
    {
        public void SendClientMessage<T>(T message) where T : class
        {
            var factory = new ConnectionFactory { HostName = "rabbitmq", Port = 5672,
                UserName = "guest",
                Password = "guest",
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("client", exclusive: false);

            var json = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "client", body: body);
        }
    }
}
