namespace ItemReadService.Services.MessageBus
{
    using System.Text;

    using RabbitMQ.Client;

    using ItemReadService.DTOs;

    public class RabbitMqService : IMessageBusService
    {
        private readonly MessageBusConfig configData;
        private readonly ConnectionFactory connectionFactory;

        public RabbitMqService(MessageBusConfig messageBusConfig)
        {
            this.configData = messageBusConfig;

            this.connectionFactory = new ConnectionFactory()
            {
                HostName = this.configData.ConnectionIP,
            };
        }

        public void SendMessage(string message, string routingKey)
        {
            using (var connection = this.connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    this.DeclareQueue(channel);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                        exchange: string.Empty,
                        routingKey: routingKey,
                        basicProperties: null,
                        body: body);
                }
            }
        }

        private void DeclareQueue(IModel channel)
        {
            channel.QueueDeclare(
                        queue: this.configData.Name,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }
    }
}
