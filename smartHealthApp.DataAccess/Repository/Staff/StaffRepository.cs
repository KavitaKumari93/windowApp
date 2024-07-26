using smartHealthApp.Common;
using smartHealthApp.Common.Enum;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess.Repository.Staff
{
    public  class StaffRepository
    {
        public async Task<int> CheckIfStaffExists(StaffModel staffModelObj)
        {
            try
            {
                var connection = new GenericRepository<Int32>(DatabaseHelper.HCOrganization);
                {
                    var result = await connection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_VerifyStaffAlreadyExists,
                        new
                        {
                            @Email = staffModelObj.Email,
                            @UserName = staffModelObj.UserName,
                            @OrganizationID= staffModelObj.OrganizationID,
                        });
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<int> SaveOrUpdateStaffDetails(StaffModel staffModelObj)
        {
            try
            {
                var connection = new GenericRepository<StaffModel>(DatabaseHelper.HCOrganization);
                {
                    var result = await connection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_InsertOrUpdateStaff,
                        new
                        {
                            @StaffID = staffModelObj.StaffID,
                            @FirstName = staffModelObj.FirstName,
                            @MiddleName = staffModelObj.MiddleName,
                            @LastName = staffModelObj.LastName,
                            @Gender = staffModelObj.Gender,
                            @DOB = DateTime.Now.AddYears(-15),
                            @DOJ = DateTime.Now,
                            @Address = staffModelObj.Address,
                            @Email = staffModelObj.Email,
                            @MaritalStatus = staffModelObj.MaritalStatus,
                            @NPINumber = staffModelObj.NPINumber,
                            @TaxId = staffModelObj.TaxId,
                            @RoleID = staffModelObj.RoleID,
                            @RoleName = staffModelObj.RoleName,
                            @PhotoPath = staffModelObj.PhotoPath,
                            @PhotoThumbnailPath = staffModelObj.PhotoThumbnailPath,
                            @UserID = staffModelObj.UserID,
                            @City = staffModelObj.City,
                            @StateID = staffModelObj.StateID,
                            @CountryID = staffModelObj.CountryID,
                            @Zip = staffModelObj.Zip,
                            @PhoneNumber = staffModelObj.PhoneNumber,
                            @IsRenderingProvider = staffModelObj.IsRenderingProvider,
                            @CAQHID = staffModelObj.CAQHID,
                            @Language = staffModelObj.Language,
                            @OrganizationID = staffModelObj.OrganizationID,
                            @EmployeeTypeID = 359782,
                            @TerminationDate = staffModelObj.TerminationDate,
                            @SSN = staffModelObj.SSN,
                            @PayrollGroupID = staffModelObj.PayrollGroupID,
                            @Latitude = staffModelObj.Latitude,
                            @Longitude = staffModelObj.Longitude,
                            @ApartmentNumber = staffModelObj.ApartmentNumber,
                            @DegreeID = staffModelObj.DegreeID,
                            @EmployeeID = staffModelObj.EmployeeID,
                            @PayRate = staffModelObj.PayRate
                        });
                    return Convert.ToInt32(result.StaffID);
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
