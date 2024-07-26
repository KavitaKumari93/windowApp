using Dapper;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.DataAccess.Repository.Organization
{
    public class MasterOrganizationRepository
    {
        public async Task<int> SaveMasterOrganizationDetails(MasterOrganizationModel masterOrganizationModelObj)
        {
            int id = 0;
            try
            {
                var dbConnection = new GenericRepository<MasterOrganizationModel>(DatabaseHelper.HCMaster);
                {
                    var result = await dbConnection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_InsertMasterOrganization,
                        new
                        {
                            @Id = masterOrganizationModelObj.Id,
                            @OrganizationName = masterOrganizationModelObj.OrganizationName,
                            @BusinessName = masterOrganizationModelObj.BusinessName,
                            @Description = masterOrganizationModelObj.Description,
                            @Address1 = masterOrganizationModelObj.Address1,
                            @ApartmentNumber = masterOrganizationModelObj.ApartmentNumber,
                            @City = masterOrganizationModelObj.City,
                            @Zip = masterOrganizationModelObj.Zip,
                            @Phone = masterOrganizationModelObj.Phone,
                            @Email = masterOrganizationModelObj.Email,
                            @Fax = masterOrganizationModelObj.Fax,
                            @Logo = masterOrganizationModelObj.Logo,
                            @ContactPersonFirstName = masterOrganizationModelObj.ContactPersonFirstName,
                            @ContactPersonMiddleName = masterOrganizationModelObj.ContactPersonMiddleName,
                            @ContactPersonLastName = masterOrganizationModelObj.ContactPersonLastName,
                            @ContactPersonPhoneNumber = masterOrganizationModelObj.ContactPersonPhoneNumber,
                            @CreatedBy = masterOrganizationModelObj.CreatedBy,
                            @CreatedDate = DateTime.UtcNow,
                            @IsActive = true
                        });
                    id = Convert.ToInt32(result.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return id;
        }
        public async Task<OrganizationModel> GetOrganizationDetailsById(int orgId)
        {
            var dbConnection = new GenericRepository<OrganizationModel>(DatabaseHelper.HCMaster);
            {
                return await dbConnection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_GetMasterOrganization, new { @id = orgId });
            }
        }

       
    }
}
