
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace Infra.Data.Context
{
    public class ApplicationDbContext : IDbContext
    {
        private readonly string connectionString;
        public ApplicationDbContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("connectionstring");
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
