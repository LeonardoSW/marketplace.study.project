using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Marketplace.Domain.Models.Configurations;
using Microsoft.Extensions.Options;

namespace Marketplace.Services.Handlers
{
    public class RabbitMqConsumeHandler : BackgroundService
    {
        private readonly RabbitMqConfigModel _config;
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqConsumeHandler(IOptions<RabbitMqConfigModel> rabbitMqConfig)
        {
            _config = rabbitMqConfig.Value;
            _factory = new ConnectionFactory { HostName = _config.HostName };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_config.Queue, false, false, false, null);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine(message);
                await Task.CompletedTask;
            };

            _channel.BasicConsume(queue: _config.Queue, autoAck: true, consumer: consumer);
            await Task.CompletedTask;
        }
    }
}
