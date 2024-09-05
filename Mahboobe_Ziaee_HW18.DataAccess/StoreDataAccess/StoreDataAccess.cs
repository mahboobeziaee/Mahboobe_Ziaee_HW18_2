//using Mahboobe_Ziaee_HW18.Domain.Store;
//using System;
//using Dapper;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Mahboobe_Ziaee_HW18.DataAccess.StoreDataAccess
//{
//    internal class StoreDataAccess : IStoreDataAccess
//    {
//        private readonly IDbConnection _connection;
//        public StoreDataAccess(IConfiguration configuration)
//        {
//            _connection = new SqlConnection(configuration.GetSection("ConnectionStrings")["Default"]);
//        }
//        List<FullGraphStore> IStoreDataAccess.GetAllStores()
//        {
//            using var con = _connection;
//            con.Open();
//            var query = @"SELECT store_id,store_name,
//            phone,email,street,city,state,zip_code FROM sales.stores where 1=1";
//            var stores = con.Query<FullGraphStore>(query);

//            con.Close();
//            return stores.ToList(); 

//        }
//    }
//}
