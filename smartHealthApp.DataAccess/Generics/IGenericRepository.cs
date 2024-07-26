using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess.Generics
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> ExcuteProcedureWithMultiResult_Async(string procedureName, object parameters);
        Task<T> ExcuteProcedureWithSingleResult_Async(string procedureName, object parameters);
        IEnumerable<T> ExcuteProcedureWithMultiResult(string procedureName, object parameters);
        T ExcuteProcedureWithSingleResult(string procedureName, object parameters, bool iscommandTimeout = false);
        IEnumerable<T> ExcuteTableWithMultiResult(string query);
    }
}
