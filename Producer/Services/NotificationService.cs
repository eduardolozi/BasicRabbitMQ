using Producer.Models;
using Services.Context;
using Services.Rabbit;

namespace Producer.Services {
    public class NotificationService {
        private readonly RabbitContext _rabbitContext;
        public NotificationService(RabbitContext rabbitContext)
        {
            _rabbitContext = rabbitContext;
        }

        public void EnviarNotificacao(Relatorio relatorio) {
            var conexao = _rabbitContext.GetConnection();
            var notificacao = new Notificacao { Id = Guid.NewGuid() };
            Notificacao.DefinirTituloPeloStatusRelatorio(notificacao, relatorio.Status);
            notificacao.Descricao = $"{relatorio.Relator}. {notificacao.Titulo}.\nObrigado!\n";
            
            RabbitService.PublishMessage<Notificacao>(conexao, notificacao, "Notificacoes", $"Notificacoes_{relatorio.Status}");            
        }
    }
}
