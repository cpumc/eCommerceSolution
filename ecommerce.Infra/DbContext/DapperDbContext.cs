
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
namespace ecommerce.Infra.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string? ConnectionString = _configuration.GetConnectionString("PostgresConnection");

            _connection = new NpgsqlConnection(ConnectionString);

        }

        public IDbConnection DbConnection => _connection;

    }
}
