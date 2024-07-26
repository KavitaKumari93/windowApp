using smartHealthApp.Common;
using smartHealthApp.DataAccess;
using smartHealthApp.DataAccess.Repository.Organization;
using smartHealthApp.DataAccess.Repository.Staff;
using smartHealthApp.DataAccess.Repository.User;
using smartHealthApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Business
{
    public class UserService
    {
        private UserRepository userRepository;
        private StaffRepository staffRepository;
        public UserService()
        {
            userRepository = new UserRepository();
            staffRepository = new StaffRepository();
        }
        public Task<IEnumerable<UserModel>> GetUsersByOrganizationId(int organizationId)
        {
            return Task.Run(async () => await userRepository.GetUserDetailsByOrganizationId(organizationId));
        }
        public async Task SaveOrUpdateUserAsync(StaffModel staffModel)
        {
            if (staffModel.StaffID == 0) // New case
            {
                // Check duplicate staff
                var staffdetails = await staffRepository.CheckIfStaffExists(staffModel);
                if (staffdetails == 0)
                {
                    // Add staff user to USER table and save to Staff

                    ///TempId's need to remove
                    staffModel.OrganizationID = 163;
                
                    staffModel.UserObj.OrganizationID = 163;
                    staffModel.UserObj.RoleID = 2;
                    staffModel.UserObj.CreatedDate = DateTime.UtcNow;
                    var userId = await userRepository.SaveOrUpdateUserDetails(staffModel.UserObj);
                    if(userId != 0)
                    {
                        staffModel.RoleID = 2;
                        staffModel.UserID = userId;
                      
                        var staff = await staffRepository.SaveOrUpdateStaffDetails(staffModel);
                    }
                }
            }
            else
            {
                // Update existing user and save to Staff
                await userRepository.SaveOrUpdateUserDetails(staffModel.UserObj);
                await staffRepository.SaveOrUpdateStaffDetails(staffModel);
            }
        }
    }
}
