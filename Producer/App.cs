using Producer.Models;
using Producer.RelatorioDataMock;
using Producer.Services;

namespace Producer {
    public class App {
        private readonly RelatorioService _relatorioService;
        private List<Relatorio> relatorios = RelatoriosMock.Relatorios;
        public App(RelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        public void Start() {
            foreach (var relatorio in relatorios) {
                _relatorioService.EnviarRelatorioParaNovoPasso(relatorio);
                Task.Delay(60000);
                _relatorioService.InserirQuantidadeDeErrosNoRelatorio(relatorio);
                Task.Delay(20000);
            }
        }
    }
}
