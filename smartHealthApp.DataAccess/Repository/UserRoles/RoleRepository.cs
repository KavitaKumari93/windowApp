using Dapper;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess.Repository.UserRoles
{
    public class RoleRepository
    {
        public async Task<int> SaveOrUpdateUserRole(UserRoleModel userRoleModel)
        {
            try
            {
                var connection = new GenericRepository<UserRoleModel>(DatabaseHelper.HCOrganization);
                {
                    var result = await connection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_InsertOrUpdateUserRole,
                        new
                        {
                            @UserType = userRoleModel.UserType,
                            @RoleName = userRoleModel.RoleName,
                            @IsActive = userRoleModel.IsActive,
                            @IsDeleted = userRoleModel.IsDeleted,
                            @OrganizationID = userRoleModel.OrganizationID
                        });
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }

        }
    }
}
