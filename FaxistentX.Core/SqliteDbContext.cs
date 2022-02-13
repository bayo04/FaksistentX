using FaxistentX.Core.Tenants;
using FaxistentX.Core.UserSemesters;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaxistentX.Core
{
    public class SqliteDbContext
    {
        readonly SQLiteAsyncConnection database;

        private static SqliteDbContext _instance;
        public static SqliteDbContext Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqliteDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sqliteDb.db3"));
                }
                return _instance;
            }
        }

        public SqliteDbContext(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Tenant>().Wait();
            database.CreateTableAsync<UserSemester>().Wait();
        }

        public SQLiteAsyncConnection GetConnection()
        {
            return database;
        }
    }
}
