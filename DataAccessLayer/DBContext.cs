using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Model;

namespace DataAccessLayer
{
    public class DBContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public DBContext()
        {
            // Папка для файла база данных
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", baseDir);

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                $@"Data Source=(LocalDB)\MSSQLLocalDB;
                   AttachDbFilename=C:\Users\lolpr\source\repos\AIS_LabWork1\DataAccessLayer\Database\Database1.mdf;
                   Integrated Security=True");
        }
    }
}
