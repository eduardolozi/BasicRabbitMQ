using Producer.Models;
using Producer.RelatorioDataMock;
using Producer.Services;
using Services.Context;
using Services.Rabbit;

namespace Producer {
    public class App {
        private readonly RelatorioService _relatorioService;
        private readonly RabbitContext _rabbitContext;
        private List<Relatorio> relatorios = RelatoriosMock.Relatorios;
        public App(RelatorioService relatorioService, RabbitContext rabbitContext)
        {
            _relatorioService = relatorioService;
            _rabbitContext = rabbitContext;
        }

        public void Start() {
            var dictQueueRoutingKey = new Dictionary<string, string> {
                {"NotificacaoEnviada", $"Notificacoes_{StatusRelatorioEnum.ENVIADO_PARA_ANALISE}"},
                {"NotificacaoCorrecoes", $"Notificacoes_{StatusRelatorioEnum.CORRECOS_PENDENTES}"},
                {"NotificacaoAprovada", $"Notificacoes_{StatusRelatorioEnum.APROVADO}"}
            };
            RabbitService.CreateQueuesForDirectExchange(_rabbitContext.GetConnection(), "Notificacoes", dictQueueRoutingKey);
            foreach (var relatorio in relatorios) {
                _relatorioService.EnviarRelatorioParaNovoPasso(relatorio);
                Task.Delay(60000);
                _relatorioService.InserirQuantidadeDeErrosNoRelatorio(relatorio);
                Task.Delay(20000);
            }
        }
    }
}
