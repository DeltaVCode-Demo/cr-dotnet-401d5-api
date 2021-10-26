using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data;
using System;

namespace SchoolAPI.Tests
{
    public abstract class DatabaseTestBase : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly SchoolDbContext _db;

        public DatabaseTestBase()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new SchoolDbContext(
                new DbContextOptionsBuilder<SchoolDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}
