using Producer.Models;

namespace Producer.Services {
    public class RelatorioService {
        private readonly NotificationService _notificationService;
        public RelatorioService(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void EnviarRelatorioParaAnalise(Relatorio relatorio) {
            Relatorio.DefinirStatusDoRelatorio(relatorio);
            _notificationService.EnviarNotificacao(relatorio);
        }
    }
}
