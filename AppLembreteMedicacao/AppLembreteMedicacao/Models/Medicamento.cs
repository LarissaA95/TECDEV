using SQLite;

namespace AppLembreteMedicacao.Models
{
    public class Medicamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        // Adicione o "= string.Empty;" ao final de cada string
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Dosagem { get; set; } = string.Empty;
        public string DataInicio { get; set; } = string.Empty;
        public string DataFim { get; set; } = string.Empty;

        public int Ativo { get; set; } = 1;
<<<<<<< HEAD
=======

        [Ignore]
        public List<Cronograma> Horarios { get; set; }
>>>>>>> 6128142e4441b3793957df6a0eb4c17fcb533a7c
    }
}