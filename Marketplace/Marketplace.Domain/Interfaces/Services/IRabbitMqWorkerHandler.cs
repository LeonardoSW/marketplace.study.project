namespace Marketplace.Domain.Interfaces.Services
{
    public interface IRabbitMqSender
    {
        bool SendMessage(string message);
    }
}
