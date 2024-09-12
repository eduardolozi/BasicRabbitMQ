using Microsoft.Extensions.Hosting;
using Producer.Models;
using Services.Context;
using Services.Rabbit;

namespace Consumer.BackgroundServices {
    public class RabbitBackgroundService : BackgroundService {
        private readonly RabbitContext _rabbitContext;
        public RabbitBackgroundService(RabbitContext rabbitContext)
        {
            _rabbitContext = rabbitContext;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            var conexao = _rabbitContext.GetConnection();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var arquivoLog = Path.Combine(path, "LogRabbitNotificacoesRelatorios.txt");
            while (!stoppingToken.IsCancellationRequested) {
                var action = (string mensagem) => {
                    using var str = new StreamWriter(arquivoLog, true);
                    str.WriteLine(mensagem);
                };
                RabbitService.ConsumeMessage<Notificacao>(conexao, action, "NotificacaoEnviada");
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
