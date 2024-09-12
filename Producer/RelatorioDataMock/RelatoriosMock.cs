using Producer.Models;

namespace Producer.RelatorioDataMock {
    public static class RelatoriosMock {
        public static List<Relatorio> Relatorios = new List<Relatorio> {
            new (Guid.NewGuid(), "Carlos", "aaaaaaaaaaaaaaaaaaaa"),
            new (Guid.NewGuid(), "Carlos", "bbbbbbbbbbbbbbbb"),
            new (Guid.NewGuid(), "Alberto", "cccccccccccccc"),
            new (Guid.NewGuid(), "Joao", "ddddddddddddddddd"),
            new (Guid.NewGuid(), "Ze", "eeeeeeeeeeeee"),
            new (Guid.NewGuid(), "Laura", "fffffffffffffffff"),
            new (Guid.NewGuid(), "Julia", "gggggggggggggggg"),
            new (Guid.NewGuid(), "Norberto", "hhhhhhhhhhhhhhh"),
            new (Guid.NewGuid(), "Josias", "iiiiiiiiiiiiiiiiii"),
            new (Guid.NewGuid(), "Clara", "jjjjjjjjjjjjjjjjjjj"),
        };
    }
}
