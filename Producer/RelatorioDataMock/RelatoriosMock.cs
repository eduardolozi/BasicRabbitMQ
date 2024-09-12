using Producer.Models;

namespace Producer.RelatorioDataMock {
    public static class RelatoriosMock {
        public static readonly List<Relatorio> Relatorios = [
            new (Guid.NewGuid(), "Carlos", "aaaaaaaaaaaaaaaaaaaa, aaaaaaaaaaaaaaaaaaaa, aaaaaaaaaaaaaaaaaaaa. aaaaaaaaaaaaaaaaaaaa. "),
            new (Guid.NewGuid(), "Carlos", "bbbbbbbbbbbbbbbb, bbbbbbbbbbbbbbbb, bbbbbbbbbbbbbbbb. bbbbbbbbbbbbbbbb, bbbbbbbbbbbbbbbb. bbbbbbbbbbbbbbbb"),
            new (Guid.NewGuid(), "Alberto", "cccccccccccccc, cccccccccccccc, cccccccccccccc. cccccccccccccc, cccccccccccccc. cccccccccccccc"),
            new (Guid.NewGuid(), "Joao", "ddddddddddddddddd, ddddddddddddddddd, ddddddddddddddddd. ddddddddddddddddd, ddddddddddddddddd. ddddddddddddddddd"),
            new (Guid.NewGuid(), "Ze", "eeeeeeeeeeeee, eeeeeeeeeeeee, eeeeeeeeeeeee. eeeeeeeeeeeee, eeeeeeeeeeeee. eeeeeeeeeeeee"),
            new (Guid.NewGuid(), "Laura", "fffffffffffffffff, fffffffffffffffff, fffffffffffffffff. fffffffffffffffff, fffffffffffffffff. fffffffffffffffff"),
            new (Guid.NewGuid(), "Julia", "gggggggggggggggg, gggggggggggggggg, gggggggggggggggg. gggggggggggggggg, gggggggggggggggg. gggggggggggggggg"),
            new (Guid.NewGuid(), "Norberto", "hhhhhhhhhhhhhhh, hhhhhhhhhhhhhhh, hhhhhhhhhhhhhhh. hhhhhhhhhhhhhhh, hhhhhhhhhhhhhhh. hhhhhhhhhhhhhhh"),
            new (Guid.NewGuid(), "Josias", "iiiiiiiiiiiiiiiiii, iiiiiiiiiiiiiiiiii, iiiiiiiiiiiiiiiiii. iiiiiiiiiiiiiiiiii, iiiiiiiiiiiiiiiiii. iiiiiiiiiiiiiiiiii"),
            new (Guid.NewGuid(), "Clara", "jjjjjjjjjjjjjjjjjjj, jjjjjjjjjjjjjjjjjjj, jjjjjjjjjjjjjjjjjjj. jjjjjjjjjjjjjjjjjjj, jjjjjjjjjjjjjjjjjjj. jjjjjjjjjjjjjjjjjjj"),
        ];
    }
}
