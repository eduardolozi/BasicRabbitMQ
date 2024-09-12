namespace Producer.Models {
    public class Notificacao {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public static void DefinirTituloPeloStatusRelatorio(Notificacao notificacao, StatusRelatorioEnum statusRelatorio) {
            notificacao.Titulo = statusRelatorio switch {
                StatusRelatorioEnum.ENVIADO_PARA_ANALISE => "O relatorio foi enviado para analise.",
                StatusRelatorioEnum.CORRECOS_PENDENTES => "O relatorio foi corrigido e possui correcoes pendentes.",
                StatusRelatorioEnum.APROVADO => "O relatorio foi aprovado pela correcao.",
                _ => throw new Exception("Erro ao processar status do relatorio.")
            };
        }

        public override string ToString() {
            return $"{Titulo}\n{Descricao}";
        }
    }
}
