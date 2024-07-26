using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess
{
    public class DbConnection : IDisposable
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;
        private IDbConnection _connection;
        private bool disposed = false;

        public DbConnection(SqlConnectionStringBuilder connectionStringBuilder)
        {
            _connectionStringBuilder =connectionStringBuilder;
        }

        public IDbConnection GetOpenConnection()
        {

            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connectionStringBuilder.ConnectionString);
                _connection.Open();
            }
            return _connection;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _connection?.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
