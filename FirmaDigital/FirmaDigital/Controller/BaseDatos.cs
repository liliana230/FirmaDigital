using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FirmaDigital.Models;
using SQLite;

namespace FirmaDigital.Controller
{
   public class BaseDatos
    {
        readonly SQLiteAsyncConnection db;

      public BaseDatos(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

          db.CreateTableAsync<Firma>().Wait();
        }

        public Task<List<Firma>> GetListFirma()
        {
            return db.Table<Firma>().ToListAsync();
        }

        public Task<Firma> GetCodFirma(int codfirma)
        {
            return db.Table<Firma>()
                .Where(i => i.cod == codfirma)
                .FirstOrDefaultAsync();
        }

        public Task<int> GuardarFirma(Firma firmas)
        {
            return firmas.cod != 0 ? db.UpdateAsync(firmas) : db.InsertAsync(firmas);
        }

        public Task<int> BorrarFirma(Firma firmas)
        {
            return db.DeleteAsync(firmas);
        }
    }

}
