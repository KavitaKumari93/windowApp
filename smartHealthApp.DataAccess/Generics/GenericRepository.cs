using Dapper;
using smartHealthApp.DataAccess.Generics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : new()
    {
        private readonly DbConnection _dbConnection;
        private bool disposedValue;

        public GenericRepository(SqlConnectionStringBuilder sqlConnectionString)
        {
            _dbConnection = new DbConnection(sqlConnectionString);
        }

        public async Task<IEnumerable<T>> ExcuteProcedureWithMultiResult_Async(string procedureName, object parameters)
        {
            using (var con = _dbConnection.GetOpenConnection())
            {
                return await con.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> ExcuteProcedureWithSingleResult_Async(string procedureName, object parameters)
        {
            using (var con = _dbConnection.GetOpenConnection())
            {
                return await con.QueryFirstOrDefaultAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> ExcuteProcedureWithMultiResult(string procedureName, object parameters)
        {
            using (var con = _dbConnection.GetOpenConnection())
            {
                return con.Query<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public T ExcuteProcedureWithSingleResult(string procedureName, object parameters, bool iscommandTimeout = false)
        {
            using (var con = _dbConnection.GetOpenConnection())
            {
                return con.QueryFirstOrDefault<T>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<T> ExcuteTableWithMultiResult(string query)
        {
            using (var con = _dbConnection.GetOpenConnection())
            {
                return con.Query<T>(query);
            }
        }


       
    }

}


