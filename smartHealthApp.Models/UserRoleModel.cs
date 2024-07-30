using smartHealthApp.Common;
using smartHealthApp.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models
{
    public class UserRoleModel : PropertyChangeHelper
    {
        private int _roleID;
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; OnPropertyChanged(); }
        }

        private string _roleName;
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; OnPropertyChanged(); }
        }
        private int _organizationID;
        public int OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; OnPropertyChanged(); }
        }
        private string _userType;
        public string UserType
        {
            get { return _userType; }
            set
            { _userType = value; OnPropertyChanged();}
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; OnPropertyChanged(); }
        }

        private bool? _isDeleted;
        public bool? IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; OnPropertyChanged(); }
        }
        private int? _deletedBy;
        public int? DeletedBy
        {
            get { return _deletedBy; }
            set { _deletedBy = value; OnPropertyChanged(); }
        }
        private DateTime? _deletedDate;
        public DateTime? DeletedDate
        {
            get { return _deletedDate; }
            set { _deletedDate = value; OnPropertyChanged(); }
        }

      

    }
}

