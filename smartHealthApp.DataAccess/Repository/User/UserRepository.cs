using smartHealthApp.Common;
using smartHealthApp.Common.Enum;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess.Repository.User
{
    public class UserRepository
    {
        public async Task<int> SaveOrUpdateUserDetails(UserModel userModelObj)
        {
            try
            {
                var connection = new GenericRepository<UserModel>(DatabaseHelper.HCOrganization);
                {
                    var result = await connection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_InsertOrUpdateUser,
                        new
                        {
                            @UserId = userModelObj.UserId,
                            @UserName = userModelObj.UserName,
                            @Password = CommonMethods.Encrypt(userModelObj.Password),
                            @AccessFailedCount = userModelObj.AccessFailedCount,
                            @IsBlock = userModelObj.IsBlock,
                            @BlockDateTime = userModelObj.BlockDateTime,
                            @IsActive = userModelObj.IsActive,
                            @RoleID = userModelObj.RoleID,
                            @IsOnline = userModelObj.IsOnline,
                            @PasswordResetDate = userModelObj.PasswordResetDate,
                            @CreatedBy = userModelObj.CreatedBy,
                            @CreatedDate = userModelObj.CreatedDate,
                            @DeletedBy = userModelObj.DeletedBy,
                            @IsDeleted = userModelObj.IsDeleted,
                            @DeletedDate = userModelObj.DeletedDate,
                            @OrganizationID = userModelObj.OrganizationID,
                            @UpdatedDate = userModelObj.UpdatedDate,
                            @UpdatedBy = userModelObj.UpdatedBy
                        });
                    return Convert.ToInt32(result.UserId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<IEnumerable<UserModel>> GetUserDetailsByOrganizationId(int Id)
        {
            try
            {
                var dbConnection = new GenericRepository<UserModel>(DatabaseHelper.HCOrganization);
                {
                    return await dbConnection.ExcuteProcedureWithMultiResult_Async(DatabaseHelper.sp_GetUsersDetailsByOrganizationId,new { @organizationId = Id });
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
