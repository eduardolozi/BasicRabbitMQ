using RabbitMQ.Client;
using Services.Rabbit;
using System.Data.Common;

namespace Services.Context {
    public class RabbitContext {
        private static RabbitContext? _instance;
        private readonly IConnection Connection;

        private RabbitContext()
        {
            Connection = RabbitService.CreateConnection("amqp://localhost:5672");
        }

        public static RabbitContext GetInstance() {
            _instance ??= new RabbitContext();
            return _instance;
        }

        public IConnection GetConnection() {
            if (_instance is null)
                throw new InvalidOperationException("Not exists a Rabbit Context");
            return Connection;
        }
    }
}
