using Dapper;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smartHealthApp.Common;

namespace smartHealthApp.DataAccess.Repository.Organization
{
    public class OrganizationRepository
    {
        public async Task<int> SaveOrUpdateOrganizationDetails(OrganizationModel OrganizationModelObj)
        {
            try
            {
                var dbConnection = new GenericRepository<OrganizationModel>(DatabaseHelper.HCOrganization);
                {
                    var result = await dbConnection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_InsertOrganization,
                        new
                        {
                            @OrganizationId = OrganizationModelObj.OrganizationID,
                            @OrganizationName = OrganizationModelObj.OrganizationName,
                            @BusinessName = OrganizationModelObj.BusinessName,
                            @Description = OrganizationModelObj.Description,
                            @Address1 = OrganizationModelObj.Address1,
                            @ApartmentNumber = OrganizationModelObj.ApartmentNumber,
                            @City = OrganizationModelObj.City,
                            @Zip = OrganizationModelObj.Zip,
                            @Phone = OrganizationModelObj.Phone,
                            @Email = OrganizationModelObj.Email,
                            @Fax = OrganizationModelObj.Fax,
                            @Logo = OrganizationModelObj.Logo,
                            @ContactPersonFirstName = OrganizationModelObj.ContactPersonFirstName,
                            @ContactPersonMiddleName = OrganizationModelObj.ContactPersonMiddleName,
                            @ContactPersonLastName = OrganizationModelObj.ContactPersonLastName,
                            @ContactPersonPhoneNumber = OrganizationModelObj.ContactPersonPhoneNumber,
                            @CreatedBy = OrganizationModelObj.CreatedBy,
                            @CreatedDate = DateTime.UtcNow,
                            @IsActive = true
                        });
                    return Convert.ToInt32(result.OrganizationID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public async Task<int> SaveOrUpdateOrganizationSMTPDetails(OrganizationSMTPModel organizationSMTPDetailObj)
        {
            var dbConnection = new GenericRepository<OrganizationSMTPModel>(DatabaseHelper.HCOrganization);
            {
                var result = await dbConnection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_InsertOrUpdateSMTPDetails,
                    new
                    {
                        @Id = organizationSMTPDetailObj.Id,
                        @ServerName = organizationSMTPDetailObj.ServerName,
                        @Port = organizationSMTPDetailObj.Port,
                        @ConnectionSecurity = organizationSMTPDetailObj.ConnectionSecurity,
                        @SMTPUserName = organizationSMTPDetailObj.SMTPUserName,
                        @SMTPPassword = CommonMethods.Encrypt(organizationSMTPDetailObj.SMTPPassword),
                        @OrganizationID = organizationSMTPDetailObj.OrganizationID,
                        @IsDeleted = organizationSMTPDetailObj.IsDeleted,
                        @IsActive = organizationSMTPDetailObj.IsActive

                    });
                return result.Id;
            }
        }
        public async Task<int> CheckOrganizationBusinessName(string businessName, int orgId)
        {
            try
            {
                var dbConnection = new GenericRepository<int>(DatabaseHelper.HCOrganization);

                var result = await dbConnection.ExcuteProcedureWithSingleResult_Async(DatabaseHelper.sp_GetOrganizationDetailsByBusinessName,
                    new
                    {
                        businessName,
                        organizationId = orgId,
                    });
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}

