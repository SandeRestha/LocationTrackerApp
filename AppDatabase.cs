using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HeatMapApp.Models;

namespace HeatMapApp.Data
{
    public static class AppDatabase
    {
        // Marked as nullable to avoid CS8618 warning since it’s initialized later.
        private static SQLiteAsyncConnection? _database;

        // Initializes the database and ensures the LocationData table exists.
        public static async Task InitAsync()
        {
            if (_database != null) return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "locations.db");
            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<LocationData>();
        }

        // Inserts a new LocationData record into the database.
        public static Task<int> AddLocationAsync(LocationData location) =>
            _database!.InsertAsync(location); // Use null-forgiving operator because _database is guaranteed to be initialized

        // Retrieves all saved location entries from the database.
        public static Task<List<LocationData>> GetLocationsAsync() =>
            _database!.Table<LocationData>().ToListAsync();
    }
}
