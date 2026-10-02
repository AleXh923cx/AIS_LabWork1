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
        /// Настройка модели данных перед её построением и использованием
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(e =>
            {
                e.ToTable("Characters");
                e.Property(c => c.Name).HasColumnType("nchar(14)").IsRequired();
                e.Property(c => c.Genus).HasColumnType("nchar(12)").IsRequired();
                e.Property(c => c.Age).HasColumnType("int").IsRequired();
            });
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
