using Producer.Models;
using System.Security.Cryptography;

namespace Producer.Services {
    public class RelatorioService {
        private readonly NotificationService _notificationService;
        public RelatorioService(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void EnviarRelatorioParaNovoPasso(Relatorio relatorio) {
            Relatorio.DefinirStatusDoRelatorio(relatorio);
            _notificationService.EnviarNotificacao(relatorio);
        }

        public void InserirQuantidadeDeErrosNoRelatorio(Relatorio relatorio) {
            var random = new Random();
            Relatorio.DefinirQuantidadeDeErros(relatorio, random.Next(15));
            EnviarRelatorioParaNovoPasso(relatorio);
        }
    }
}
