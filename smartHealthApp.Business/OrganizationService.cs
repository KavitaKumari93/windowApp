using smartHealthApp.Common;
using smartHealthApp.Common.Enum;
using smartHealthApp.DataAccess.Repository.Organization;
using smartHealthApp.DataAccess.Repository.User;
using smartHealthApp.DataAccess.Repository.UserRoles;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using smartHealthApp.Common.Properties;
using smartHealthApp.DataAccess;

namespace smartHealthApp.Business
{
    public class OrganizationService
    {
        private MasterOrganizationRepository masterOrganizationRepository;
        private OrganizationRepository organizationRepository;
        private UserRepository userRepository;
        private RoleRepository roleRepository;
        public OrganizationService()
        {
            masterOrganizationRepository = new MasterOrganizationRepository();
            organizationRepository = new OrganizationRepository();
            userRepository = new UserRepository();
            roleRepository = new RoleRepository();
        }
        public async Task<int> SaveOrganizationAsync(OrganizationModel organizationModelObj)
        {


            // Save master organization
            var organizationId = await masterOrganizationRepository.SaveMasterOrganizationDetails(organizationModelObj);
            if (organizationId > 0)
            {
                // // Update Organization model with organization ID of masterorganization  and then Save organization
                organizationModelObj.OrganizationID = organizationId;
                organizationModelObj.OrganizationSMTPModelObj.OrganizationID = organizationId;
                await Task.Run(async () => await organizationRepository.SaveOrUpdateOrganizationDetails(organizationModelObj));

                //Save Default Roles for this organization
                foreach (Roles role in Enum.GetValues(typeof(Roles)))
                {
                    UserRoleModel userRoles = new UserRoleModel
                    {
                        UserType = role.ToString().ToUpper(),
                        RoleName = role.ToString(),
                        IsActive = true,
                        IsDeleted = false,
                        OrganizationID = organizationId
                    };
                    await roleRepository.SaveOrUpdateUserRole(userRoles);
                }
                //Add User
                organizationModelObj.UserModelObj.OrganizationID = organizationId;
                organizationModelObj.UserModelObj.CreatedBy = null;// token.UserID;
                organizationModelObj.UserModelObj.CreatedDate = DateTime.UtcNow;
                organizationModelObj.UserModelObj.IsActive = true;
                organizationModelObj.UserModelObj.RoleID = (int)Roles.Admin;
                await Task.Run(async () => await userRepository.SaveOrUpdateUserDetails(organizationModelObj.UserModelObj));

                // Update SMTP model with organization ID
                organizationModelObj.OrganizationSMTPModelObj.OrganizationID = organizationId;
                // Save SMTP details
                await Task.Run(async () => await SaveOrUpdateOrganizationSMTPDetails(organizationModelObj.OrganizationSMTPModelObj));

                //Save Agency locallyy
                SaveAgencyDetailsLocally(organizationModelObj);
            }
            return organizationId;
        }
        public void SaveAgencyDetailsLocally(OrganizationModel organizationModel)
        {
            string baseDirectory = Path.GetPathRoot(Environment.SystemDirectory);
            string folderPath = Path.Combine(Path.Combine(baseDirectory, DefaultSettings.SettingFileFolder), DefaultSettings.SettingSubFolder);

            //directory exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            CommonMethods.SaveToXmlFile(organizationModel, (Path.Combine(folderPath, DefaultSettings.SettingFileName)));
        }
        public Task<int> CheckOrganizationBusinessName(string businessName)
        {
            return Task.Run(async () => await organizationRepository.CheckOrganizationBusinessName(businessName));
        }
        public  Task<int> SaveOrUpdateOrganizationSMTPDetails(OrganizationSMTPModel organizationSMTPDetailObj)
        {
            return Task.Run(async () => await organizationRepository.SaveOrUpdateOrganizationSMTPDetails(organizationSMTPDetailObj));
        }
    }
}





