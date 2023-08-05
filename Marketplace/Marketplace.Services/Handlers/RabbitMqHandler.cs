using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Marketplace.Domain.Interfaces.Services;

namespace Marketplace.Services.Handlers
{
    public class RabbitMqHandler : BackgroundService
    {
        private readonly IUserService _userService;
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqHandler(IUserService userService)
        {
            _userService = userService;
            _factory = new ConnectionFactory
            {
                HostName = "http://localhost/",
                Port = 15672,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                _userService.QualquerCoisa(message);

            };
            _channel.BasicConsume(queue: "hello",
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}
