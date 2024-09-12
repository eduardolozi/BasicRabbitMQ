using RabbitMQ.Client;
using System.Text;

namespace Services.Rabbit {
    public static class RabbitService {

        public static IConnection CreateConnection(string url) {
            var connectionFactory = new ConnectionFactory { Uri = new Uri(url) };
            return connectionFactory.CreateConnection();
        }

        public static IModel CreateQueuesForDirectExchange(IConnection connection, string exchangeName, Dictionary<string, string> queues) {
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            foreach (var queue in queues) {
                channel.QueueDeclare(queue.Key, true, false, false, null);
                channel.QueueBind(queue.Key, exchangeName, queue.Value, null);
            }

            return channel;
        }

        public static void PublishMessage(IModel channel, string message, string exchangeName, string routingKey) {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchangeName, routingKey, null, messageBytes);
        }
    }
}
