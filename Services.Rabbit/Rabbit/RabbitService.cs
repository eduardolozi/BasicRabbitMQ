using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;

namespace Services.Rabbit {
    public static class RabbitService {

        public static IConnection CreateConnection(string url) {
            var connectionFactory = new ConnectionFactory { Uri = new Uri(url) };
            return connectionFactory.CreateConnection();
        }

        public static IModel CreateQueuesForDirectExchange(IConnection connection, string exchangeName, Dictionary<string, string> dictQueueRoutingKey) {
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            foreach (var element in dictQueueRoutingKey) {
                channel.QueueDeclare(element.Key, true, false, false, null);
                channel.QueueBind(element.Key, exchangeName, element.Value, null);
            }

            return channel;
        }

        public static void PublishMessage<T>(IModel channel, T messageValue, string exchangeName, string routingKey) {
            var messageSerialized = JsonSerializer.Serialize(messageValue);
            var messageBytes = Encoding.UTF8.GetBytes(messageSerialized);
            channel.BasicPublish(exchangeName, routingKey, null, messageBytes);
        }

        public static void ConsumeMessage<T>(IConnection connection, Action<T> action, string queueName) {
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (ch, ea) => {
                var data = GetData<T>(ea.Body);
                
                action(data);

                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(queueName, false, consumer);
        }

        private static T GetData<T>(ReadOnlyMemory<byte> bodyBytes) {
            var body = Encoding.UTF8.GetString(bodyBytes.ToArray());
            return JsonSerializer.Deserialize<T>(body);
        }
    }
}
