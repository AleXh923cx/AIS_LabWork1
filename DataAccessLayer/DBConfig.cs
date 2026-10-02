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
            // Папка для файла база данных (находится в AppData/Local, для обоих View)
            var dbDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "RpgTree");

            if (!Directory.Exists(dbDir))
                Directory.CreateDirectory(dbDir);
            AppDomain.CurrentDomain.SetData("DataDirectory", dbDir);

            ConnectionString = ConfigurationManager.ConnectionStrings["RpgTreeDb"]?.ConnectionString
                ?? throw new InvalidOperationException(
                "Строка подключения 'RpgTreeDb' не найдена в App.config.");
        }
    }
}
