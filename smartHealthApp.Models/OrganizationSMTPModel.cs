using smartHealthApp.Common;
using smartHealthApp.Models.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartHealthApp.Models
{
    public class OrganizationSMTPModel : BaseEntityModel
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        private string _serverName;
        public string ServerName
        {
            get => _serverName;
            set { _serverName = value; OnPropertyChanged(); }
        }
        private string _port;
        public string Port
        {
            get => _port;
            set { _port = value; OnPropertyChanged(); }
        }
        private string _connectionSecurity;
        public string ConnectionSecurity
        {
            get => _connectionSecurity;
            set { _connectionSecurity = value; OnPropertyChanged(); }
        }
        private string _smtpUserName;
        public string SMTPUserName
        {
            get => _smtpUserName;
            set { _smtpUserName = value; OnPropertyChanged(); }
        }
        private string _smtpPassword;
        public string SMTPPassword
        {
            get => _smtpPassword;
            set { _smtpPassword = value; OnPropertyChanged(); }
        }
        private string _smtpConfirmPassword;
        public string SMTPConfirmPassword
        {
            get => _smtpConfirmPassword;
            set { _smtpConfirmPassword = value; OnPropertyChanged(); }
        }
        private int _organizationID;
        public int OrganizationID
        {
            get => _organizationID;
            set { _organizationID = value; OnPropertyChanged(); }
        }
    }
}

