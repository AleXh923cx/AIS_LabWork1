using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Configuration;
using Model;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public static string ConnectionString = 
            ConfigurationManager.ConnectionStrings["RpgTreeDb"]?.ConnectionString
            ?? throw new InvalidOperationException(
                "Строка подключения 'CharactersDb' не найдена в App.config.");

        public DBContext()
        {
            // Папка для файла база данных
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", baseDir);

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
