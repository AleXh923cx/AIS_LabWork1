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
        /// Настройка модели данных перед её построением и использованием
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(e =>
            {
                e.ToTable("Characters", table => {
                    table.HasCheckConstraint(
                        "CK_Characters_Age_NonNegative",
                        "[Age] >= 0");
                });

                e.HasKey(c => c.Id);

                e.Property(c => c.Id)
                    .ValueGeneratedOnAdd();

                e.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode();

                e.Property(c => c.Genus)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode();

                e.Property(c => c.Age)
                    .IsRequired();

                e.Ignore(c => c.Level);
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
