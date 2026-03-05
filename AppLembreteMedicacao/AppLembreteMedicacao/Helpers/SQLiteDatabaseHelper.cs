using AppLembreteMedicacao.Models;
using SQLite;

namespace AppLembreteMedicacao.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Medicamento>().Wait();
            _conn.CreateTableAsync<Horario>().Wait();
            _conn.CreateTableAsync<HistoricoUso>().Wait();
            _conn.CreateTableAsync<Usuario>().Wait();
        }
// MEDICAMENTO

        public Task<int> InsertMedicamento(Medicamento m)
            => _conn.InsertAsync(m);

        public Task<List<Medicamento>> GetMedicamentos()
            => _conn.Table<Medicamento>().ToListAsync();

        public Task<int> UpdateMedicamento(Medicamento m)
            => _conn.UpdateAsync(m);

        public Task<int> DeleteMedicamento(int id)
            => _conn.DeleteAsync<Medicamento>(id);

        // HORARIO

        public Task<int> InsertHorario(Horario h)
            => _conn.InsertAsync(h);

        public Task<List<Horario>> GetHorarios(int medicamentoId)
            => _conn.Table<Horario>()
                    .Where(h => h.MedicamentoId == medicamentoId)
                    .ToListAsync();

        public Task<int> DeleteHorario(int id)
            => _conn.DeleteAsync<Horario>(id);

        // HISTÓRICO 

        public Task<int> InsertHistorico(HistoricoUso h)
            => _conn.InsertAsync(h);

        public Task<List<HistoricoUso>> GetHistorico(int medicamentoId)
            => _conn.Table<HistoricoUso>()
                    .Where(h => h.MedicamentoId == medicamentoId)
                    .ToListAsync();

        public Task<int> AtualizarStatusHistorico(HistoricoUso h)
            => _conn.UpdateAsync(h);

        // USUARIO

        public Task<int> InsertUsuario(Usuario u)
            => _conn.InsertAsync(u);

        public Task<Usuario> GetUsuarioByEmail(string email)
            => _conn.Table<Usuario>()
                    .Where(u => u.Email == email)
                    .FirstOrDefaultAsync();

        public Task<int> UpdateUsuario(Usuario u)
            => _conn.UpdateAsync(u);

        public Task<int> DeleteUsuario(int id)
            => _conn.DeleteAsync<Usuario>(id);

    }
}
