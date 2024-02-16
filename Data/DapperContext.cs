using System.Data;
using Npgsql;

namespace CQRS.Data{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection")??"";
        }
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);
    }
}