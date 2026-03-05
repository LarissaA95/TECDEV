using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using AppLembreteMedicacao.Models;

namespace AppLembreteMedicacao.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Medicamento>().Wait();
            _conn.CreateTableAsync<Cronograma>().Wait();
            _conn.CreateTableAsync<HistoricoUso>().Wait();
            _conn.CreateTableAsync<Usuario>().Wait();
        }
        // MEDICAMENTO

        public Task<int> InsertMedicamento(Medicamento m)
        {
            return _conn.InsertAsync(m);
        }

        public Task<List<Medicamento>> GetMedicamentos()
            => _conn.Table<Medicamento>().ToListAsync();

        public Task<int> UpdateMedicamento(Medicamento m)
        {
            return _conn.UpdateAsync(m);
        }
        public Task<int> DeleteMedicamento(int id)
            => _conn.DeleteAsync<Medicamento>(id);

        // CRONOGRAMA

        public Task<int> InsertCronograma(Cronograma c)
        {
            return _conn.InsertAsync(c);
        }
        public Task<List<Cronograma>> GetCronogramaPorMedicacao(int medicacaoId)
        {
            return _conn.Table<Cronograma>()
            .Where(c => c.MedicamentoId == medicacaoId)
            .ToListAsync();
        }
        public Task<int> UpdateCronograma(Cronograma c)
        {
            return _conn.UpdateAsync(c);
        }

        public Task<int> DeleteCronograma(int id)
        {
            return _conn.DeleteAsync<Cronograma>(id);
        }

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
        {
            return _conn.InsertAsync(u);
        }

        public Task<List<Usuario>> GetUsuarios()
        {
            return _conn.Table<Usuario>().ToListAsync();
        }

        public Task<Usuario> GetUsuarioEmail(string email)
        {
            return _conn.Table<Usuario>()
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}