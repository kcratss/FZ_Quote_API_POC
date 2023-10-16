using Dapper;
using FloorzapTestAPI.Interfaces;
using FloorzapTestAPI.Model;
using System.Data;

namespace FloorzapTestAPI.Repository
{
    public class Repository<T>: BaseRepository, IRepository<T> where T : class
    {
        public Repository(IConfiguration configuration):base(configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<T> ExecuteSPSingleAsync(string spName, DynamicParameters parameters)
        {
            using (var vConn = OpenConnection())
            {
                return await vConn.QuerySingleAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> ExecuteSPSingleAsync(string spName)
        {
            using (var vConn = OpenConnection())
            {
                return await vConn.QuerySingleAsync<T>(spName, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> ExecuteSPAsync(string spName, DynamicParameters parameters)
        {
            using (var vConn = OpenConnection())
            {
                return await vConn.QueryAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> ExecuteSPAsync<T1>(string spName, DynamicParameters parameters, Func<T, T1, T> map, string splitOn)
        {
            using (var vConn = OpenConnection())
            {
                return await vConn.QueryAsync<T, T1, T>(spName, map, parameters, commandType: CommandType.StoredProcedure, splitOn: splitOn);
            }
        }
    }
}
