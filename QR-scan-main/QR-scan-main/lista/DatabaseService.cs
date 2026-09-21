using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lista_zakupow
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;
        public DatabaseService()
        {
            string databasePath = Path.Combine(
                FileSystem.AppDataDirectory,
                "tablety.db3");

            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Item>().Wait();
        }

        public async Task<List<Item>> PobierzFilmyAsync()
        {
            return await _database.Table<Item>().ToListAsync();
        }

        public async Task<Item> PobierzFilmPoID(int idTabletu)
        {
            return await _database.FindAsync<Item>(idTabletu);
        }

        public async Task DodajFilmAsync(Item tablet)
        {
            await _database.InsertAsync(tablet);
        }

        public async Task AktualizujFilmAsync(Item tablet)
        {
            await _database.UpdateAsync(tablet);
        }

        public async Task UsunFilmAsync(Item tablet)
        {
            int wynik = await _database.DeleteAsync<Item>(tablet.Id);
            System.Diagnostics.Debug.WriteLine(
                $"DELETE ID={tablet.Id}, wynik={wynik}");
        }

    }
}
