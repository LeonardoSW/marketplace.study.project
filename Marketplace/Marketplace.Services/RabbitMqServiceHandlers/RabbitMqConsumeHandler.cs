using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Marketplace.Domain.Models.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Marketplace.Domain.Models.Message;
using Marketplace.Domain.Interfaces.Repositories;
using Marketplace.Domain.Entities;

namespace Marketplace.Services.Handlers
{
    public class RabbitMqConsumeHandler : BackgroundService
    {
        private readonly RabbitMqConfigModel _config;
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IOrderRepository _orderRepository;

        public RabbitMqConsumeHandler(IOptions<RabbitMqConfigModel> rabbitMqConfig, IOrderRepository orderRepository)
        {
            _config = rabbitMqConfig.Value;
            _factory = new ConnectionFactory { HostName = _config.HostName };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_config.Queue, false, false, false, null);
            _orderRepository = orderRepository;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {

                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var objMessage = JsonConvert.DeserializeObject<ProcessNewOrderMessageModel>(message);

                    var newOrder = new OrderEntity();

                    await _orderRepository.ProcessNewOrderAsync(newOrder);
                }
                catch (Exception)
                {
                    _channel.BasicNack(0, false, true);
                }

                await Task.CompletedTask;
            };

            _channel.BasicConsume(queue: _config.Queue, autoAck: true, consumer: consumer);
            await Task.CompletedTask;
        }
    }
}
