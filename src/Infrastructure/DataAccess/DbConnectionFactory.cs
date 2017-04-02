using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Infrastructure.DataAccess
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[0];
            DbProviderFactory factory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
            IDbConnection connection = factory.CreateConnection();
            connection.ConnectionString = connectionStringSettings.ConnectionString;
            return connection;
        }
    }
}
