using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private static string _tableName => typeof(T).Name + "s";

        private static PropertyInfo[] PropertiesWithoutKey =>
            typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && p.CanWrite && p.Name != nameof(IDomainObject.Id))
                .ToArray();

        public void Add(T entity)
        {
            var props = PropertiesWithoutKey;

            string columns = string.Join(", ", props.Select(p => $"[{p.Name}]"));
            string values = string.Join(", ", props.Select(p => $"@{p.Name}"));

            string sql = $"INSERT INTO {_tableName} ({columns}) VALUES ({values});";

            using var connection = new SqlConnection(DBConfig.ConnectionString);
            connection.Execute(sql, entity);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(DBConfig.ConnectionString);

            string sql = $"DELETE FROM {_tableName} WHERE [Id] = @Id;";
            connection.Execute(sql, new { Id = id });
        }

        public IEnumerable<T> ReadAll()
        {
            using var connection = new SqlConnection(DBConfig.ConnectionString);

            string sql = $"SELECT * FROM {_tableName};";
            return connection.Query<T>(sql);
        }

        public T ReadById(int id)
        {
            using var connection = new SqlConnection(DBConfig.ConnectionString);

            string sql = $"SELECT * FROM {_tableName} WHERE [Id] = @Id;";
            return connection.QueryFirstOrDefault<T>(sql, new { Id = id });
        }

        public void Update(T entity)
        {
            var props = PropertiesWithoutKey;

            string sets = string.Join(", ", props.Select(p => $"[{p.Name}] = @{p.Name}"));
            
            string sql = $"UPDATE {_tableName} SET {sets} WHERE [Id] = @Id;";

            using var connection = new SqlConnection(DBConfig.ConnectionString);
            connection.Execute(sql, entity);
        }
    }
}
