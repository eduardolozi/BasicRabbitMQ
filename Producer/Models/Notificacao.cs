namespace Producer.Models {
    public class Notificacao {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public static void DefinirTituloPeloStatusRelatorio(Notificacao notificacao, StatusRelatorioEnum statusRelatorio) {
            notificacao.Titulo = statusRelatorio switch {
                StatusRelatorioEnum.ENVIADO_PARA_ANALISE => "O relaório foi enviado para análise",
                StatusRelatorioEnum.CORRECOS_PENDENTES => "O relatório foi corrigido e possui correções pendentes",
                StatusRelatorioEnum.APROVADO => "O relatório foi aprovado pela correção",
                _ => throw new Exception("Erro ao processar status do relatório")
            };
        }
    }
}
