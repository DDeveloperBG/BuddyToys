namespace ClinicService.Services.MessageBus
{
    public interface IMessageBusService
    {
        void SendMessage(string message, string routingKey);
    }
}
