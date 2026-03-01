using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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