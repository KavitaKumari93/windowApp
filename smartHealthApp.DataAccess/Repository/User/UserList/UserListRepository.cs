using smartHealthApp.Common;
using smartHealthApp.Models;
using smartHealthApp.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess.Repository.User.UserList
{
    public class UserListRepository
    {


        public async Task<IEnumerable<StaffModel>> GetStaffUsers(ListingFiltterModel filterModel)
        {
            try
            {
                var connection = new GenericRepository<StaffModel>(DatabaseHelper.HCOrganization);
                {
                    return await connection.ExcuteProcedureWithMultiResult_Async(DatabaseHelper.sp_GetStaffUsers,
                    new
                    {
                        @OrganizationId = GlobalData.organizationId,
                        @LocationIds = string.Empty,
                        @RoleIds = string.Empty,
                        @SearchKey = string.Empty,
                        @StartWith = string.Empty,
                        @Tags = string.Empty,
                        @SortColumn = string.Empty,
                        @SortOrder = string.Empty,
                        @PageNumber = 1,
                        @PageSize = 20
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
