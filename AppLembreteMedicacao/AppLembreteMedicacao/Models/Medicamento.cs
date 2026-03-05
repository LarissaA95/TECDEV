using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;

namespace AppLembreteMedicacao.Models
{
    public class Medicamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [NotNull]
        public string Dosagem { get; set; }

        [NotNull]
        public string DataInicio { get; set; }

        public string DataFim { get; set; }

        public int Ativo { get; set; } = 1;

        [Ignore]
        public List<Cronograma> Horarios { get; set; }
    }
}
