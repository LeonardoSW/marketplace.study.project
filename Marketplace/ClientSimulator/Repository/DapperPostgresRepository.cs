using ClientSimulator.Repository.DapperQueires;
using Dapper;
using Npgsql;

namespace ClientSimulator.Repository
{
    public class DapperPostgresRepository
    {
        private readonly string _connectionString;

        public DapperPostgresRepository()
            => _connectionString = "Server=database-1.cv62ty9hdyti.us-east-2.rds.amazonaws.com;Port=5432;User Id=postgres;Password=2S92n&Tu2ai43QTiI5M3vVn5a^$!;SslMode=Require;Trust Server Certificate=true;Database=postgres";

        public async Task<List<long>> GetProductIds()
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var query = Queries.GetProductIds();
            var result = await connection.QueryAsync<long>(query);

            return result.ToList();
        }

        public async Task<List<string>> GetUsersCpfAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);

            var query = Queries.GetCpfUsers();
            var result = await connection.QueryAsync<string>(query);

            return result.ToList();
        }
    }
}
