using smartHealthApp.Common;
using smartHealthApp.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models
{
    public class UserModel :BaseEntityModel
    {
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; OnPropertyChanged(); }
        }
       
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        //Dont to save in db
        private string _confirmPasswordString;
        public string ConfirmPasswordString
        {
            get { return _confirmPasswordString; }
            set { _confirmPasswordString = value; OnPropertyChanged(); }
        }
        private int _accessFailedCount;
        public int AccessFailedCount
        {
            get { return _accessFailedCount; }
            set { _accessFailedCount = value; OnPropertyChanged(); }
        }
        private bool _isBlock;
        public bool IsBlock
        {
            get { return _isBlock; }
            set { _isBlock = value; OnPropertyChanged(); }
        }
        private DateTime? _blockDateTime;
        public DateTime? BlockDateTime
        {
            get { return _blockDateTime; }
            set { _blockDateTime = value; OnPropertyChanged(); }
        }
        
        private int _roleID;
        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; OnPropertyChanged(); }
        }
        private bool _isOnline;
        public bool IsOnline
        {
            get { return _isOnline; }
            set { _isOnline = value; OnPropertyChanged(); }
        }
        private int _organizationID;
        public int OrganizationID
        {
            get { return _organizationID; }
            set { _organizationID = value; OnPropertyChanged(); }
        }
        
        private Nullable<DateTime> _passwordResetDate;
        public Nullable<DateTime> PasswordResetDate
        {
            get { return _passwordResetDate; }
            set { _passwordResetDate = value; OnPropertyChanged(); }
        }



    }
}
