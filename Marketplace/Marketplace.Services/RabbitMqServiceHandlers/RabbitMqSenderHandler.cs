using Marketplace.Domain.Interfaces.Services;
using Marketplace.Domain.Models.Configurations;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Marketplace.Services.RabbitMqServiceHandlers
{
    public class RabbitMqSenderHandler : IRabbitMqSenderHandler
    {
        private readonly RabbitMqConfigModel _config;
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqSenderHandler(IOptions<RabbitMqConfigModel> rabbitMqConfig)
        {
            _config = rabbitMqConfig.Value;
            _factory = new ConnectionFactory() { HostName = _config.HostName };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_config.Queue, false, false, false, null);
        }

        public bool SendMessage<T>(T input)
        {
            try
            {
                var message = JsonConvert.SerializeObject(input);
                _channel.BasicPublish("", _config.Queue, null, Encoding.Default.GetBytes(message));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
