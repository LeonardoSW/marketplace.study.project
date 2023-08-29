using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Marketplace.Domain.Models.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Marketplace.Domain.Models.Message;
using Marketplace.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Marketplace.Services.Handlers
{
    public class RabbitMqConsumerHandler : BackgroundService
    {
        private RabbitMqConfigModel _config;
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private IServiceProvider _serviceProvider;

        public RabbitMqConsumerHandler(IServiceProvider serviceProvider)
        {
            CreateScope(serviceProvider);
            _factory = new ConnectionFactory { HostName = _config.HostName };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_config.Queue, false, false, false, null);
            _channel.BasicQos(0, 15, false);
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                try
                {
                    var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var objMessage = JsonConvert.DeserializeObject<ProcessNewOrderMessageModel>(message);

                    if (string.IsNullOrWhiteSpace(objMessage.Cpf))
                        return;

                    //"Why create a new scope per message?" to avoid concurrent use of instances of the database.
                    using IServiceScope scope = _serviceProvider.CreateScope();
                    var orderService = scope.ServiceProvider.GetRequiredService<IOrderService>();

                    await orderService.ProcessNewOrderAsync(objMessage);
                }
                catch
                {
                    _channel.BasicNack(ea.DeliveryTag, false, true);
                }
                finally
                {
                    _channel.BasicAck(ea.DeliveryTag, false);
                }

                await Task.CompletedTask;
            };

            _channel.BasicConsume(queue: _config.Queue, autoAck: false, consumer: consumer);
            return Task.CompletedTask;
        }
        private void CreateScope(IServiceProvider serviceProvider)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            _config = scope.ServiceProvider.GetRequiredService<IOptions<RabbitMqConfigModel>>().Value;
        }
    }
}
