namespace Marketplace.Domain.Interfaces.Services
{
    public interface IRabbitMqSenderHandler
    {
        bool SendMessage<T>(T input);
    }
}
