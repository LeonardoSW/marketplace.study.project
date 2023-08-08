namespace Marketplace.Domain.Interfaces.Services
{
    public interface IRabbitMqSender
    {
        bool SendMessage<T>(T input);
    }
}
