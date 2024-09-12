using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Models {
    public class Relatorio {
        public Relatorio(Guid id, string relator, string conteudo)
        {
            Id = id;
            Relator = relator;
            Conteudo = conteudo;
        }

        public Guid Id { get; init; }
        public string Relator {  get; set; }
        public string Conteudo { get; set; }
        public int? ErrosEncontrados { get; set; }
        public StatusRelatorioEnum Status { get; set; }
        
        public static void DefinirStatusDoRelatorio(Relatorio relatorio) {
            relatorio.Status = relatorio.ErrosEncontrados switch {
                null => StatusRelatorioEnum.ENVIADO_PARA_ANALISE,
                0 => StatusRelatorioEnum.APROVADO,
                > 0 => StatusRelatorioEnum.CORRECOS_PENDENTES,
                _ => throw new Exception("Nao foi possivel definir status para o relatório")
            };
        }
    }

    public enum StatusRelatorioEnum {
        NAO_ENVIADO,
        ENVIADO_PARA_ANALISE,
        CORRECOS_PENDENTES,
        APROVADO
    }
}
