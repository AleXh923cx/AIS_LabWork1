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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Database1.mdf");

            optionsBuilder.UseSqlServer(
                $@"Data Source=(LocalDB)\MSSQLLocalDB;
                   AttachDbFilename={dbPath};
                   Integrated Security=True;
                   Database=RpgTreeCharactersDb");
        }
    }
}
