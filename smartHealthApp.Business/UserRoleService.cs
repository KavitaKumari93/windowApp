using smartHealthApp.DataAccess;
using smartHealthApp.DataAccess.Repository.Organization;
using smartHealthApp.DataAccess.Repository.User;
using smartHealthApp.DataAccess.Repository.UserRoles;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Business
{
    public class UserRoleService
    {

        private RoleRepository userRoleRepository;
        public UserRoleService()
        {
            userRoleRepository = new RoleRepository();
        }
        public Task<int> SaveOrUpdateUserRole(UserRoleModel userRoleModelObj)
        {
            return Task.Run(async () => await userRoleRepository.SaveOrUpdateUserRole(userRoleModelObj));
        }
    }
}
