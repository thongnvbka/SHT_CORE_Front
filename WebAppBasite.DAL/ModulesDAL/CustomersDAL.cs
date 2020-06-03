using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAppBasite.DAL.BaseDAL;
using WebAppBasite.Models.ProjectModels;

namespace WebAppBasite.DAL.ModulesDAL
{
   public class CustomersDAL  : BaseDALClass<Customers>
    {
        private string _tableName;
        public CustomersDAL(string tableName) : base(tableName)
        {
            _tableName = tableName;
        }
        public  async void InsertCustomer(string name, string phone, string service, int CreatedAt)
        {
            using (var connection = CreateConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var paramaters = new DynamicParameters();
                paramaters.Add("@CusNamee", name);
                paramaters.Add("@Cusphone", phone);
                paramaters.Add("@Service", service);
                paramaters.Add("@CreatedAt", CreatedAt);
                var result = await connection.ExecuteAsync("usp_insert_customer", paramaters, null, null, System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
