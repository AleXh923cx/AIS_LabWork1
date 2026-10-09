using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Model;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Reflection;

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
            // modelBuilder.Entity<Character>(e =>
            // {
            //     e.ToTable("Characters", table => {
            //         table.HasCheckConstraint(
            //             "CK_Characters_Age_NonNegative",
            //             "[Age] >= 0");
            //     });
            // 
            //     e.HasKey(c => c.Id);
            // 
            //     e.Property(c => c.Id)
            //         .ValueGeneratedOnAdd();
            // 
            //     e.Property(c => c.Name)
            //         .IsRequired()
            //         .HasMaxLength(14)
            //         .IsUnicode();
            // 
            //     e.Property(c => c.Genus)
            //         .IsRequired()
            //         .HasMaxLength(12)
            //         .IsUnicode();
            // 
            //     e.Property(c => c.Age)
            //         .IsRequired();
            // 
            //     e.Ignore(c => c.Level);
            // });

            base.OnModelCreating(modelBuilder);

            // Все типы из Model, реализующий IDomainObject
            var domainTypes = typeof(IDomainObject).Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IDomainObject).IsAssignableFrom(t));

            foreach (var type in domainTypes)
            {
                var entity = modelBuilder.Entity(type);

                string tableName = type.Name.EndsWith("s")
                    ? type.Name
                    : type.Name + "s";
                entity.ToTable(tableName);

                entity.HasKey(nameof(IDomainObject.Id));

                foreach (var prop in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    // Вычисляемые свойства (только геттер) игнорируем
                    if (!prop.CanWrite)
                    {
                        entity.Ignore(prop.Name);
                        continue;
                    }

                    if (prop.PropertyType == typeof(string))
                    {
                        var maxLen = prop
                            .GetCustomAttribute<MaxLengthAttribute>()?.Length
                            ?? 255;

                        entity.Property(prop.Name)
                            .IsUnicode(true)
                            .HasMaxLength(maxLen);

                        if (prop.GetCustomAttribute<RequiredAttribute>() != null)
                            entity.Property(prop.Name).
                                IsRequired();
                    }
                }
            }
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
