using Dapper;

namespace FloorzapTestAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> ExecuteSPSingleAsync(string spName, DynamicParameters parameters);
        Task<T> ExecuteSPSingleAsync(string spName);
        Task<IEnumerable<T>> ExecuteSPAsync(string spName, DynamicParameters parameters);
        Task<IEnumerable<T>> ExecuteSPAsync<T1>(string spName, DynamicParameters parameters, Func<T, T1, T> map, string splitOn);
    }
}
