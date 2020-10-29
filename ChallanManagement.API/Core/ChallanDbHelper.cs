using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ChallanManagement.API
{
    public class ChallanDbHelper
    {
        private static IConfiguration _configuration;

        private static string ConnectionString;
        public ChallanDbHelper(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }
        public static string GetConnectionString()
        {
            ConnectionString = _configuration.GetValue<string>("ChallanDB:ConnectionString");
            return ConnectionString;
        }
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=MYSYS\\SQLEXPRESS;Initial Catalog=challanDB;Integrated Security=True");
        }
    }
}
