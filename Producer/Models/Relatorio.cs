using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Models {
    public class Relatorio {
        public Guid Id { get; set; }
        public string Relator {  get; set; }
        public string Titulo { get; set; }
        public int ErrosEncontrados { get; set; }
    }
}
