using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CRUD.Data.Default
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DataBase"));
        }
    }
}