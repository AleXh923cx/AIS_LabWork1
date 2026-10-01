using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccessLayer
{
    internal static class DBConfig
    {
        // Строка подключения, определяет по App.config
        public static string ConnectionString { get; }

        static DBConfig()
        {
            // Папка для файла база данных
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", baseDir);

            ConnectionString = ConfigurationManager.ConnectionStrings["RpgTreeDb"]?.ConnectionString
                ?? throw new InvalidOperationException(
                "Строка подключения 'RpgTreeDb' не найдена в App.config.");
        }
    }
}
