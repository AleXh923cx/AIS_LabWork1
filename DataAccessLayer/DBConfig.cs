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
        public static string ConnectionString =
            ConfigurationManager.ConnectionStrings["RpgTreeDb"]?.ConnectionString
            ?? throw new InvalidOperationException(
                "Строка подключения 'CharactersDb' не найдена в App.config.");
    }
}
