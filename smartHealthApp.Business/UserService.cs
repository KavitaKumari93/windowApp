using smartHealthApp.Common;
using smartHealthApp.Common.Enum;
using smartHealthApp.DataAccess;
using smartHealthApp.DataAccess.Repository.Organization;
using smartHealthApp.DataAccess.Repository.Staff;
using smartHealthApp.DataAccess.Repository.User;
using smartHealthApp.DataAccess.Repository.User.UserList;
using smartHealthApp.Models;
using smartHealthApp.Models.RequestModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Business
{
    public class UserService
    {
        private UserRepository userRepository;
        private StaffRepository staffRepository;
        private UserListRepository userListRepository;
        public UserService()
        {
            userRepository = new UserRepository();
            staffRepository = new StaffRepository();
            userListRepository = new UserListRepository();
        }
        public Task<IEnumerable<UserModel>> GetUsersByOrganizationId(int organizationId)
        {
            return Task.Run(async () => await userRepository.GetUserDetailsByOrganizationId(organizationId));
        }
        public async Task<int> SaveOrUpdateUserAsync(StaffModel staffModel)
        {
            int staffId = 0;
            if (staffModel.StaffID == 0) // New case
            {
                // Check duplicate staff
                var staffdetails = await staffRepository.CheckIfStaffExists(staffModel);
                if (staffdetails == 0)
                {
                    // Add staff user to USER table and save to Staff

                    ///TempId's need to remove
                    staffModel.OrganizationID = GlobalData.organizationId;
                    staffModel.UserObj.OrganizationID = staffModel.OrganizationID;
                    staffModel.UserObj.RoleID = (int)Roles.Provider;
                    staffModel.UserObj.CreatedDate = DateTime.UtcNow;
                    var userId = await userRepository.SaveOrUpdateUserDetails(staffModel.UserObj);
                    if(userId != 0)
                    {
                        staffModel.RoleID = (int)Roles.Provider;
                        staffModel.UserID = userId;
                        staffId = await staffRepository.SaveOrUpdateStaffDetails(staffModel);
                       
                    }
                }
            }
            else
            {
                // Update existing user and save to Staff
                await userRepository.SaveOrUpdateUserDetails(staffModel.UserObj);
                await staffRepository.SaveOrUpdateStaffDetails(staffModel);
            }
            return staffId;
        }
       

        public async Task<IEnumerable<StaffModel>> GetStaffUsers(ListingFiltterModel filtterModel)
        {
            return await userListRepository.GetStaffUsers(filtterModel);
        }
    }
}
