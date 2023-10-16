using System.Data.SqlClient;
using System.Data;

namespace FloorzapTestAPI.Repository
{
    public class BaseRepository
    {
        private readonly IConfiguration configuration;

        public BaseRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection(configuration.GetConnectionString("development"));
            connection.Open();
            return connection;
        }
    }
}
