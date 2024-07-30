using smartHealthApp.Business;
using smartHealthApp.Common;
using smartHealthApp.Common.Helpers;
using smartHealthApp.Common.AppMessenger;
using smartHealthApp.Common.Enum;
using smartHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace smartHealthApp.ViewModel
{
    public class SetUpAgencyViewModel : PropertyChangeHelper
    {
        private SynchronizationContext synchronizationContext;
        private string _message = string.Empty;
        private string _newLine = Environment.NewLine;
        #region Constructor
        public SetUpAgencyViewModel()
        {
            OrganizationModelObj = new OrganizationModel();
            OrganizationModelObj.UserModelObj = new UserModel();
            OrganizationModelObj.OrganizationSMTPModelObj = new OrganizationSMTPModel();

            SaveAgencyCommmand = new RelayCommandHelper(x => SaveOrganization());
        }
        #endregion

        private OrganizationModel _organizationModelObj;
        public OrganizationModel OrganizationModelObj
        {
            get { return _organizationModelObj; }
            set { _organizationModelObj = value; OnPropertyChanged(); }
        }
        #region Commands
        public RelayCommandHelper SaveAgencyCommmand { get; set; }
        #endregion

        #region Methods
        private void SaveOrganization()
        {
            synchronizationContext = SynchronizationContext.Current;
            if (!ValidateInfo())
            {
                var result = new OrganizationService().SaveOrganizationAsync(OrganizationModelObj);
                if (result != null)
                {
                    synchronizationContext.Send(new SendOrPostCallback(o =>
                    {
                        MessageBox.Show("Organization Saved Successfully!!");
                    }), null);
                }
                NavigateToLoginScreen();
            }
            else
            {
                synchronizationContext.Send(new SendOrPostCallback(o =>
                {
                    MessageBox.Show(_message);
                }), null);
              
            }
        }

        public void NavigateToLoginScreen()
        {
            AppMessenger.Navigate(NavigationPages.Login);
        }

        public bool ValidateInfo()
        {
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.AppendLine("Please provide required information :");

            bool err = false;
            if (string.IsNullOrEmpty(OrganizationModelObj.OrganizationName))
            {
                messageBuilder.AppendLine("Organization Name");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.BusinessName))
            {
                messageBuilder.AppendLine("Business Name");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.UserModelObj.UserName))
            {
                messageBuilder.AppendLine("UserName,");
                err = true;
            }

            if (string.IsNullOrEmpty(OrganizationModelObj.UserModelObj.Password))
            {
                messageBuilder.AppendLine("Password");
                err = true;
            }

            _message = messageBuilder.ToString().TrimEnd(); 

            return err;
        }


        #endregion
    }
}
