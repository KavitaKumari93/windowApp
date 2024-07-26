using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models
{
    public class OrganizationModel:MasterOrganizationModel
    {
        private int _organizationID;
        public int OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; OnPropertyChanged(); }
        }
        private OrganizationSMTPModel _organizationSMTPModelObj;
        public OrganizationSMTPModel OrganizationSMTPModelObj
        {
            get => _organizationSMTPModelObj;
            set { _organizationSMTPModelObj = value; OnPropertyChanged(); }
        }
        private  UserModel _userModelObj;
        public  UserModel UserModelObj
        {
            get => _userModelObj;
            set { _userModelObj = value; OnPropertyChanged(); }
        }
        
    }
}
