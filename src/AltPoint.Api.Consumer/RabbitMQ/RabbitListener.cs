using AltPoint.Api.Consumer.RabbitMQ;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

public class RabbitListener
{
    private readonly RabbitMQConfiguration _configuration;
    public RabbitListener(IOptions<RabbitMQConfiguration> options)
    {
        _configuration = options.Value;
    }
    public IConnection CreateChannel()
    {
        ConnectionFactory connection = new ConnectionFactory()
        {
            UserName = "guest",
            Password = "guest",
            HostName = "rabbitmq",
            Port = 5672
        };
        connection.DispatchConsumersAsync = true;
        var channel = connection.CreateConnection();
        return channel;
    }
}