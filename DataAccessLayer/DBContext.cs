using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Configuration;
using Model;

namespace DataAccessLayer
{
    /// <summary>
    /// Это для Entity Framework
    /// </summary>
    public class DBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public DBContext()
        {
            Database.EnsureCreated(); // Проверка на существование БД
        }

        /// <summary>
        /// При конфигурации, построитель настроек пытается использовать БД по строке подключении
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DBConfig.ConnectionString);
        }
    }
}
