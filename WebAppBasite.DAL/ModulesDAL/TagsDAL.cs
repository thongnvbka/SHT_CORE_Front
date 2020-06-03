using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBasite.DAL.BaseDAL;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.DAL.ModulesDAL
{
 public  class TagsDAL : BaseDALClass<Tags>
    {
        private string _tableName;
        public TagsDAL(string tableName) : base(tableName)
        {
            _tableName = tableName;
        }
        public async Task<IEnumerable<Tags>> GetTagList()
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<Tags>("SELECT * FROM dbo.Tags WHERE show_athome = 1 ORDER BY index_athome DESC", null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }
        public async Task<IEnumerable<Tags>> GetTagListbyId(string slug)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();

                var paramaters = new DynamicParameters();
                paramaters.Add("@slug", slug);
                var result = await connection.QueryAsync<Tags>("sp_list_Tag_byId", paramaters, null, null, System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
