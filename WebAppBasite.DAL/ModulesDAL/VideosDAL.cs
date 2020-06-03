using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBasite.DAL.BaseDAL;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.DAL.ModulesDAL
{
   public class VideosDAL : BaseDALClass<Videos>
    {
        private string _tableName;
        public VideosDAL(string tableName) : base(tableName)
        {
            _tableName = tableName;
        }
        public async Task<IEnumerable<Videos>> GetListVideo()
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var result = await connection.QueryAsync<Videos>("SELECT * FROM dbo.[Videos]", null, null, null, System.Data.CommandType.Text);
                return result;
            }
        }
    }
}
