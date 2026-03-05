using SQLite;

namespace AppLembreteMedicacao.Models
{
    public class Horario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public int MedicamentoId { get; set; }

        [NotNull]
        public string Hora { get; set; }
    }
}