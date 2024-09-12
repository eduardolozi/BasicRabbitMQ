using RabbitMQ.Client;
using Services.Rabbit;

namespace Services.Context {
    public class RabbitContext {
        private static RabbitContext _instance;
        public static IConnection Connection { get; private set; }

        private RabbitContext()
        {
            Connection = RabbitService.CreateConnection("");
        }

        public static RabbitContext GetConnetction() {
            _instance ??= new RabbitContext();
            return _instance;
        }
    }
}
