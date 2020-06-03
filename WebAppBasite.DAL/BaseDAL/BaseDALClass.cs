using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAppBasite.DAL.BaseDAL
{
    public class BaseDALClass<T> :IDisposable
    {
        private readonly string _tableName;
        /// <summary>
        /// Generate new connection based on connection string
        /// </summary>
        /// <returns></returns>
        /// 
        public BaseDALClass(string tableName)
        {
            _tableName = tableName;

        }
        private SqlConnection SqlConnection()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            // return new SqlConnection("Server=.;Database=Saohathanh;User ID=sa;Password=123456;");
            return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        protected IDbConnection CreateConnection()
        {
            var conn = SqlConnection();
            return conn;
        }
        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
 
        #region Get
        public async Task<IEnumerable<T>> GetAllList()
        {
            string sql = $"SELECT * FROM {_tableName}";
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                return await connection.QueryAsync<T>(sql, null, null, null, System.Data.CommandType.Text);
            }
        }
        public async Task<T> Get(int id)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@id", id);
                var result = await connection.QueryAsync<T>("Get_Product_ById", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result.Single();
            }
        }
        #endregion

        #region Inssert 
        public async Task InsertAsync(T t)
        {
            var insertQuery = GenerateInsertQuery();

            using (var connection = CreateConnection())
            {
                await connection.ExecuteAsync(insertQuery, t);
            }
        }
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO {_tableName} ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"[{prop}],"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
        #endregion


        public async Task UpdateAsync(T t)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                await connection.ExecuteAsync(updateQuery, t);
            }
        }
      
        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE {_tableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private bool disposed = false;
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
              
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        public void Dispose()
        {
           // Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
