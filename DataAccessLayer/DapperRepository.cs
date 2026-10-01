using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private static string _tableName
        {
            get
            {
                return typeof(T).Name == "Character"
                    ? "Characters"
                    : typeof(T).Name + "s";
            }
        }

        public void Add(T entity)
        {
            using var connection = new SqlConnection(DBConfig.ConnectionString);

            string sql = $"INSERT INTO {_tableName} (Name, Genus, Age) VALUES (@Name, @Genus, @Age);";
            connection.Execute(sql, entity);
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(DBConfig.ConnectionString);

            string sql = $"DELETE FROM {_tableName} WHERE Id = @Id;";
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

            string sql = $"SELECT * FROM {_tableName} WHERE Id = @Id;";
            return connection.QueryFirstOrDefault<T>(sql, new { Id = id });
        }

        public void Update(T entity)
        {
            using var connection = new SqlConnection(DBConfig.ConnectionString);

            string sql = $"UPDATE {_tableName} SET Name = @Name, Genus = @Genus, Age = @Age WHERE Id = @Id;";
            connection.Execute(sql, entity);
        }
    }
}
