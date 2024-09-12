using RabbitMQ.Client;
using Services.Rabbit;

namespace Services.Context {
    public class RabbitContext {
        private RabbitContext? _instance;
        private readonly IConnection Connection;

        private RabbitContext()
        {
            Connection = RabbitService.CreateConnection("");
        }

        public IConnection GetConnection() {
            _instance ??= new RabbitContext();
            return _instance.Connection;
        }
    }
}
